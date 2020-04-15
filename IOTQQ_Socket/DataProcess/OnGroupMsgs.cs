using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTQQ_Socket.DataProcess
{
    public static class OnGroupMsgs
    {
        public static async void Process(string json)
        {
            await Task.Yield();
            try
            {
                Data.Get.OnGroupMsgs.Root data = LitJson.JsonMapper.ToObject<Data.Get.OnGroupMsgs.Root>(json);
                if (data.CurrentPacket.Data.FromUserId==Api.QQ)
                {
                    return;
                }
                switch (data.CurrentPacket.Data.MsgType)
                {
                    case "TextMsg":
                        Plugins.Replay.GetGroupMsg(data.CurrentPacket.Data.FromGroupId,data.CurrentPacket.Data.Content);
                        Plugins.RandomPic.GetGroupMsg(data.CurrentPacket.Data.FromGroupId, data.CurrentPacket.Data.Content);
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
