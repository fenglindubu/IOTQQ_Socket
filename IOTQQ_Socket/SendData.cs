using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTQQ_Socket
{
  public static  class SendData
    {
        public static async void SendGroupVoice(long groupID,string voiceURL, string voiceBase64Buf)
        {
            await Task.Yield();
            Data.Send.SendGroupVoice.Root sendGroupVoice = new Data.Send.SendGroupVoice.Root();
            sendGroupVoice.toUser = groupID;
            sendGroupVoice.sendToType = 2;
            sendGroupVoice.sendMsgType = "VoiceMsg";
            sendGroupVoice.content = string.Empty;
            sendGroupVoice.content = string.Empty;
            sendGroupVoice.groupid = 0;
            sendGroupVoice.atUser = 0;

            if (string.IsNullOrEmpty(voiceURL))
            {
                sendGroupVoice.voiceUrl = string.Empty;
            }
            else
            {
                sendGroupVoice.voiceUrl = voiceURL;
            }


            if (string.IsNullOrEmpty(voiceBase64Buf))
            {
                sendGroupVoice.voiceBase64Buf = string.Empty;
            }
            else
            {
                sendGroupVoice.voiceBase64Buf = voiceBase64Buf;
            }
            string json = LitJson.JsonMapper.ToJson(sendGroupVoice);
            HttpHelper.Post(Api.SendMsg, json);

        }
      
        public static async void SendGroupTextMsg(long groupID,string msg,long atUser=0)
        {
            await Task.Yield();
            Data.Send.SendGroupTextMsg.Root sendGroupTextMsg = new Data.Send.SendGroupTextMsg.Root();
            sendGroupTextMsg.toUser = groupID;
            sendGroupTextMsg.sendToType = 2;
            sendGroupTextMsg.sendMsgType = "TextMsg";
            sendGroupTextMsg.content = msg;
            sendGroupTextMsg.groupid = 0;
            sendGroupTextMsg.atUser = atUser;
            string json = LitJson.JsonMapper.ToJson(sendGroupTextMsg);
            HttpHelper.Post(Api.SendMsg,json);
        }

        public static async void SendGroupPic(long groupID,string picUrl,string picBase64,bool isQuueue=false)
        {
            await Task.Yield();
            Data.Send.SendGroupPic.Root data = new Data.Send.SendGroupPic.Root();
            data.toUser = groupID;
            data.sendToType = 2;
            data.sendMsgType = "PicMsg";
            data.content = string.Empty;
            data.groupid = 0;
            data.atUser = 0;
            if (string.IsNullOrEmpty(picUrl))
            {
                data.picUrl = string.Empty;
            }
            else
            {
                data.picUrl = picUrl;
            }

            if (string.IsNullOrEmpty(picBase64))
            {
                data.picBase64Buf = string.Empty;
            }
            else
            {
                data.picBase64Buf = picBase64;
            }
            data.fileMd5 = string.Empty;
            string json = LitJson.JsonMapper.ToJson(data);
            HttpHelper.Post(Api.SendMsg, json,isQuueue);
        }

    }
}
