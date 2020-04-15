using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTQQ_Socket.Plugins
{
   public static class RandomPic
    {

        private static readonly string key = "来点图";
        public static List<string> picPath = new List<string>();

        public static void InitPicList()
        {
            GetDirectoryFiles(System.Configuration.ConfigurationManager.AppSettings["RandomPicPath"]);
            Console.WriteLine("Random Pic Count: {0}",picPath.Count);
        }


        private static void GetDirectoryFiles(string CurrentDirectPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(CurrentDirectPath);
            FileSystemInfo[] fileSystemInfos = directoryInfo.GetFileSystemInfos();
            foreach (var item in fileSystemInfos)
            {
                if (item is DirectoryInfo)
                {
                    GetDirectoryFiles(item.FullName);
                }
                else
                {
                    picPath.Add(item.FullName);
                }
            }
        }
        public static async void GetGroupMsg(long groupID,string msg)
        {
            if (msg!=key || picPath.Count==0)
            {
                return;
            }
            await Task.Yield();

            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iRoot = BitConverter.ToInt32(buffer, 0);
            Random random = new Random(iRoot);
            int temp = random.Next(0, picPath.Count - 1);
            SendData.SendGroupPic(groupID, null, GetPicBase64(picPath[temp]),true);


        }
        private static string GetPicBase64(string path)
        {
            using (FileStream filestream = new FileStream(path, FileMode.Open))
            {
                byte[] bt = new byte[filestream.Length];

                //调用read读取方法
                filestream.Read(bt, 0, bt.Length);
                var base64Str = Convert.ToBase64String(bt);

                return base64Str;
            }
        }
    }
}
