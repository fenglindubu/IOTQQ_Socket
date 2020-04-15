using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTQQ_Socket.Data.Send
{
  public class SendGroupPic
    {
        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public long toUser { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int sendToType { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string sendMsgType { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string content { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long groupid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public long atUser { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string picUrl { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string picBase64Buf { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string fileMd5 { get; set; }
        }

    }
}
