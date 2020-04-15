using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTQQ_Socket.Data.Get
{
    public class OnGroupMsgs
    {
        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public long FromGroupId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string FromGroupName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long FromUserId { get; set; }
            /// <summary>
            ///
            /// </summary>
            public string FromNickName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Content { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string MsgType { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long MsgTime { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long MsgSeq { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long MsgRandom { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string RedBaginfo { get; set; }
        }

        public class CurrentPacket
        {
            /// <summary>
            /// 
            /// </summary>
            public string WebConnId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Data Data { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public CurrentPacket CurrentPacket { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long CurrentQQ { get; set; }
        }
    }
}
