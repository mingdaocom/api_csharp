using System;
using System.Collections.Generic;
using System.Text;
using Open.MingdaoSDK.Common;
using Open.MingdaoSDK.Entity;
using System.Collections.Specialized;

namespace Open.MingdaoSDK
{
    public class Message : MDAPIBase
    {
        public Message(Parameter u_key) : base(u_key) { }

        /// <summary>
        /// 获取当前登录用户私人消息列表（列举所有私信的发送人列表,按照最新消息时间排序）
        /// </summary>
        /// <returns></returns>
        public NewMessageListModel GetAllMessage()
        {
            string ResultList = base.SyncRequest(TypeOption.MD_MESSAGE_ALL, null, null);
            if (!string.IsNullOrEmpty(ResultList))
            {
                return XmlSerializationHelper.XmlToObject<NewMessageListModel>(ResultList);
            }
            return null;
        }
        /// <summary>
        ///获取当前登录用户与其它单个用户的私人消息列表
        /// </summary>
        /// <param name="uid">发送消息对象的用户编号</param>
        /// <param name="pageindex">当前页码（以1开始，1代表第一页）</param>
        /// <param name="pagesize">指定要返回的记录条数</param>
        /// <returns></returns>
        public MessageListModel GetMessageByUser(string uid, string pageindex, string pagesize)
        {
            MessageListModel meg = new MessageListModel();
            meg.Error_Code = "10001";
            if (string.IsNullOrEmpty(uid)) { return meg; }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("u_id", uid));
            if (!string.IsNullOrEmpty(pageindex))
            {
                Que.Add(new Parameter("pageindex", pageindex));
            }
            if (!string.IsNullOrEmpty(pagesize))
            {
                Que.Add(new Parameter("pagesize", pagesize));
            }
            string ResultLsit = base.SyncRequest(TypeOption.MD_MESSAGE_LIST, Que, null);
            if (!string.IsNullOrEmpty(ResultLsit))
                return XmlSerializationHelper.XmlToObject<MessageListModel>(ResultLsit);

            return null;
        }
        /// <summary>
        ///获取当前登录用户未读私人消息数量
        /// </summary>
        /// <returns></returns>
        public string GetCurrentUnreadCount()
        {
            string Count = base.SyncRequest(TypeOption.MD_MESSAGE_UNREADCOUNT, null, null);
            return Count;
        }
        /// <summary>
        ///向某个用户发送一条私人消息
        /// </summary>
        /// <param name="receiveID">接收消息者</param>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public string SendMessage(string receiveID, string msg)
        {
            if (string.IsNullOrEmpty(receiveID) || string.IsNullOrEmpty(msg)) { return null; }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("u_id", receiveID));
            Que.Add(new Parameter("msg", msg));
            string Result = base.SyncRequest(TypeOption.MD_MESSAGE_CREATE, Que, null);

            return Result;
        }
        /// <summary>
        /// 删除当前登陆用户私人消息
        /// </summary>
        /// <param name="MegID">消息编号</param>
        /// <returns></returns>
        public string DelCurrentMeg(string MegID)
        {
            if (string.IsNullOrEmpty(MegID)) { return "Error:10001"; }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("m_id", MegID));
            return base.SyncRequest(TypeOption.MD_MESSAGE_DELETE, Que, null);
        }
        /// <summary>
        /// 标记某条消息已经阅读
        /// </summary>
        /// <param name="MegID">消息编号</param>
        /// <returns></returns>
        public string MarkRead(string MegID)
        {
            if (string.IsNullOrEmpty(MegID)) { return "Error:10001"; }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("m_id", MegID));
            return base.SyncRequest(TypeOption.MD_MESSAGE_READ, Que, null);
        }
    }
}
