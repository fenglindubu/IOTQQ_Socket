using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTQQ_Socket.Data.Get
{
    public class OnEvents
    {
        public class EventData
        {
            /// <summary>
            /// 
            /// </summary>
            public long UserID { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long FromType { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long Field_9 { get; set; }
            /// <summary>
            ///  
            /// </summary>
            public string Content { get; set; }
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
            public int Action { get; set; }
        }

        public class EventMsg
        {
            /// <summary>
            /// 
            /// </summary>
            public long FromUin { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long ToUin { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string MsgType { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long MsgSeq { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Content { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string RedBaginfo { get; set; }
        }

        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public EventData EventData { get; set; } 
            /// <summary>
            /// 
            /// </summary>
            public EventMsg EventMsg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string EventName { get; set; }
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
            public Data Data { get; set; } = new Data();
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
