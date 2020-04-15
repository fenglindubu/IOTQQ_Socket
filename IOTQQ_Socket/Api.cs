using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTQQ_Socket
{
    public static class Api
    {
        //从AppConfig获取
        public static readonly long QQ= 123456789;
        public static readonly string ClientApi = "http://127.0.0.1:8888/";

        //处理好友请求
        public static readonly string DealFriend = ClientApi + string.Format("v1/LuaApiCaller?qq={0}&funcname=DealFriend&timeout=10", QQ);
        //发送消息
        public static readonly string SendMsg = ClientApi + string.Format("v1/LuaApiCaller?qq={0}&funcname=SendMsg&timeout=10", QQ);
        
    }
}
