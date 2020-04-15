using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IOTQQ_Socket
{
    public static class HttpHelper
    {

        private class QueueData
        {
            public string url { get; set; }
            public string postData { get; set; }
        }

        private static List<QueueData> queueDatas = new List<QueueData>();
        public static async void QueueSendInit()
        {
            while (true)
            {
                await Task.Delay(1000);
                if (queueDatas.Count>=1)
                {
                    var data = queueDatas[0];
                    queueDatas.Remove(data);
                    Post(data.url, data.postData);
                }
            }
        }
        public static string Post(string url, string postData, bool isQueue=false)
        {
            if (isQueue)
            {
                QueueData queueData = new QueueData();
                queueData.url = url;
                queueData.postData = postData;
                queueDatas.Add(queueData);
                return "Queue";
            }
            return Post(url, postData, "application/json");
        }
        private static string Post(string url, string postData, string contentType)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = contentType;
                request.Method = "POST";
                request.Timeout = 10000;

                byte[] bytes = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = bytes.Length;
                Stream writer = request.GetRequestStream();
                writer.Write(bytes, 0, bytes.Length);
                writer.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException(), Encoding.UTF8);
                string result = reader.ReadToEnd();
                response.Close();
                return result;
            }
            catch (Exception ee)
            {
           
                Console.WriteLine(ee);
                return null;
            }
           
        }

    }
}
