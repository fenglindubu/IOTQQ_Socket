using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IOTQQ_Socket.Plugins
{
    public static class Replay
    {
        private static List<Data.Temp.Replay> datas = new List<Data.Temp.Replay>();

        private static ReaderWriterLockSlim rwl = new ReaderWriterLockSlim();
        //设置 别人发送多少次 复读
        private static int getMsgCount = 3;
        public static async void GetGroupMsg(long groupID, string msg)
        {
            await Task.Yield();
            //防止刷屏
            if (msg.Length>=10)
            {
                return;
            }

            try
            {
                rwl.EnterWriteLock();
                var item = datas.Find(i => i.GroupID == groupID);
                if (item==null)
                {
                    Data.Temp.Replay replay = new Data.Temp.Replay();
                    replay.GroupID = groupID;
                    replay.Msg = new List<string>();
                    replay.Msg.Add(msg);
                    datas.Add(replay);
                    return;
                }

                item.Msg.Add(msg);
                if (item.Msg.Count>getMsgCount)
                {
                    item.Msg.RemoveAt(0);
                }

                if (item.Msg.FindAll(i => i == msg).Count >= getMsgCount)
                {
                    //发送复读信息
                    SendData.SendGroupTextMsg(item.GroupID, msg);
                    item.Msg = new List<string>();
                    return;
                }


            }
            finally
            {
                rwl.ExitWriteLock();
            }

        }
        

    }
}
