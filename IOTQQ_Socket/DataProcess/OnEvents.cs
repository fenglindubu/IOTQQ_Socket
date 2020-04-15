using Newtonsoft.Json;
using SocketIOClient.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTQQ_Socket.DataProcess
{
    public static class OnEvents
    {

        public static async void Process(string json)
        {
            await Task.Yield();
            try
            {
                Data.Get.OnEvents.Root data = LitJson.JsonMapper.ToObject<Data.Get.OnEvents.Root>(json);

                switch (data.CurrentPacket.Data.EventName)
                {
                    case "ON_EVENT_FRIEND_ADD":
                        //Action 1忽略2同意3拒绝
                        string temp = HttpHelper.Post(Api.DealFriend, LitJson.JsonMapper.ToJson(data.CurrentPacket.Data.EventData));
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
        }
    }
}
