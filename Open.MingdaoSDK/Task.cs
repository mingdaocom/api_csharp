using System;
using System.Collections.Generic;
using System.Text;
using Open.MingdaoSDK;
using Open.MingdaoSDK.Common;
using Open.MingdaoSDK.Entity;
using System.Collections.Specialized;

namespace Open.MingdaoSDK
{
    public class Task : MDAPIBase
    {
        public Task(Parameter u_key) : base(u_key) { }
        /// <summary>
        /// 获取当前登录用户参与的任务列表
        /// </summary>
        /// <returns></returns>
        public TaskResultModel GetMyJoined()
        {
            string Result = base.SyncRequest(TypeOption.MD_TASK_MYJOINED, null, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<TaskResultModel>(Result);

            return null;
        }
        /// <summary>
        /// 获取当前登录用户已经完成的并且参与的任务列表
        /// </summary>
        /// <param name="pageindex">指定当前的页码</param>
        /// <param name="pagesize">指定要返回的记录条数(默认值20，最大值100)</param>
        /// <returns></returns>
        public TaskResultModel GetMyJoinFinished(string pageindex, string pagesize)
        {
            List<Parameter> Query = new List<Parameter>();
            if (!string.IsNullOrEmpty(pageindex))
            {
                Query.Add(new Parameter("pageindex", pageindex));
            }
            if (!string.IsNullOrEmpty(pagesize))
            {
                Query.Add(new Parameter("pagesize", pagesize));
            }
            string Result = base.SyncRequest(TypeOption.MD_TASK_MYJOINEDFINISHED, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<TaskResultModel>(Result);

            return null;

        }
        /// <summary>
        /// 获取当前登录用户托付的任务列表
        /// </summary>
        /// <returns></returns>
        public TaskResultModel GetMyAssign()
        {
            string Result = base.SyncRequest(TypeOption.MD_TASK_MYASSIGN, null, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<TaskResultModel>(Result);

            return null;
        }
        /// <summary>
        /// 获取当前登录用户已经完成的并且托付的任务列表
        /// </summary>
        /// <param name="pageindex">指定当前的页码</param>
        /// <param name="pagesize">指定要返回的记录条数(默认值20，最大值100)</param>
        /// <returns></returns>
        public TaskResultModel GetMyAssignFishished(string pageindex, string pagesize)
        {
            List<Parameter> Query = new List<Parameter>();
            if (!string.IsNullOrEmpty(pageindex))
            {
                Query.Add(new Parameter("pageindex", pageindex));
            }
            if (!string.IsNullOrEmpty(pagesize))
            {
                Query.Add(new Parameter("pagesize", pagesize));
            }
            string Result = base.SyncRequest(TypeOption.MD_TASK_MYASSIGNFINISHED, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<TaskResultModel>(Result);

            return null;
        }
        /// <summary>
        ///获取当前登录用户负责的任务列表
        /// </summary>
        /// <returns></returns>
        public TaskResultModel GetMyChange()
        {
            string Result = base.SyncRequest(TypeOption.MD_TASK_MYCHARGE, null, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<TaskResultModel>(Result);

            return null;
        }
        /// <summary>
        /// 获取当前登录用户已经完成的并且负责的任务列表
        /// </summary>
        /// <param name="pageindex">指定要返回的记录页码</param>
        /// <param name="pagesize">指定要返回的记录条数</param>
        /// <returns></returns>
        public TaskResultModel GetMyChangeFinished(string pageindex, string pagesize)
        {
            List<Parameter> Query = new List<Parameter>();
            if (!string.IsNullOrEmpty(pageindex))
            {
                Query.Add(new Parameter("pageindex", pageindex));
            }
            if (!string.IsNullOrEmpty(pagesize))
            {
                Query.Add(new Parameter("pagesize", pagesize));
            }
            string Result = base.SyncRequest(TypeOption.MD_TASK_MYCHARGEFINISHED, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<TaskResultModel>(Result);

            return null;
        }
        /// <summary>
        /// 获取当前网络所有任务隶属的项目
        /// </summary>
        /// <returns></returns>
        public TaskProjectResultModel GetProject()
        {
            string Result = base.SyncRequest(TypeOption.MD_TASK_PROJECT, null, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<TaskProjectResultModel>(Result);

            return null;
        }
        /// <summary>
        ///获取当前登录用户未读任务讨论数量
        /// </summary>
        /// <returns></returns>
        public string GetUnreadCount()
        {
            string Result = base.SyncRequest(TypeOption.MD_TASK_UNREADCOUNT, null, null);

            return Result;
        }
        /// <summary>
        /// 根据任务编号获取单条任务内容
        /// </summary>
        /// <param name="TID">任务编号</param>
        /// <returns></returns>
        public TaskDetailResultModel GetTaskDetail(string TID)
        {
            TaskDetailResultModel T = new TaskDetailResultModel();
            T.Error_Code = "10001";
            if (string.IsNullOrEmpty(TID)) { return T; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("t_id", TID));
            string Result = base.SyncRequest(TypeOption.MD_TASK_DETAIL, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<TaskDetailResultModel>(Result);

            return null;
        }
        /// <summary>
        ///根据任务编号获取单条任务的讨论列表信息
        /// </summary>
        /// <param name="TID">任务编号</param>
        /// <param name="pageindex">若指定此参数，则只返回ID比max_id小的动态更新（即比max_id发表时间早的动态更新）</param>
        /// <param name="pagesize">指定要返回的记录条数</param>
        /// <returns></returns>
        public TaskReplymentResultModel GetTaskReply(string TID, string pageindex, string pagesize)
        {
            TaskReplymentResultModel T = new TaskReplymentResultModel();
            T.Error_Code = "10001";
            if (string.IsNullOrEmpty(TID)) { return T; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("t_id", TID));
            if (!string.IsNullOrEmpty(pageindex))
            {
                Query.Add(new Parameter("pageindex", pageindex));
            }
            if (!string.IsNullOrEmpty(pagesize))
            {
                Query.Add(new Parameter("pagesize", pagesize));
            }

            string Result = base.SyncRequest(TypeOption.MD_TASK_REPLY, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<TaskReplymentResultModel>(Result);

            return null;
        }
        /// <summary>
        /// 创建新任务
        /// </summary>
        /// <param name="t_title">任务标题</param>
        /// <param name="t_des">任务描述</param>
        /// <param name="t_ed">任务截止日期，yyyy-MM-dd形式</param>
        /// <param name="u_id">指定的任务负责人</param>
        /// <param name="t_pid">指定的隶属项目</param>
        /// <returns></returns>
        public string Create(string t_title, string t_des, string t_ed, string u_id, string t_pid)
        {
            if (string.IsNullOrEmpty(t_title) || string.IsNullOrEmpty(t_ed) || string.IsNullOrEmpty(u_id)) { return "Error:10001"; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("t_title", t_title));
            Query.Add(new Parameter("t_ed", t_ed));
            Query.Add(new Parameter("u_id", u_id));
            if (!string.IsNullOrEmpty(t_des))
            {
                Query.Add(new Parameter("t_des", t_des));
            }
            if (!string.IsNullOrEmpty(t_pid))
            {
                Query.Add(new Parameter("t_pid", t_pid));
            }
            string Result = base.SyncRequest(TypeOption.MD_TASK_CREATE, Query, null);

            return Result;
        }
        /// <summary>
        /// 根据任务编号标记任务完成
        /// </summary>
        /// <param name="TID">任务编号</param>
        /// <returns></returns>
        public string Finish(string TID)
        {
            if (string.IsNullOrEmpty(TID)) { return "Error:10001"; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("t_id", TID));
            string Result = base.SyncRequest(TypeOption.MD_TASK_FINISH, Query, null);

            return Result;
        }
        /// <summary>
        /// 增加一个任务的讨论
        /// </summary>
        /// <param name="t_id">讨论的任务编号</param>
        /// <param name="r_id">讨论编号（可以对别人的讨论进行回复）[可选]</param>
        /// <param name="r_msg">讨论的消息内容</param>
        /// <param name="r_img">要上传的图片。仅支持JPEG,GIF,PNG图片,目前上传图片大小限制为<5M。</param>
        /// <returns></returns>
        public string AddReply(string t_id, string r_id, string r_msg, string r_img)
        {
            if (string.IsNullOrEmpty(t_id) || string.IsNullOrEmpty(r_msg)) { return "Error:10001"; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("t_id", t_id));
            Query.Add(new Parameter("r_msg", r_msg));
            if (!string.IsNullOrEmpty(r_id))
            {
                Query.Add(new Parameter("r_id", r_id));
            }
            if (!string.IsNullOrEmpty(r_img))
            {
                Query.Add(new Parameter("r_img", r_img));
            }
            string Result = base.SyncRequest(TypeOption.MD_TASK_ADDREPLY, Query, null);
            return Result;
        }
        /// <summary>
        ///根据任务编号删除任务
        /// </summary>
        /// <param name="t_id">任务编号</param>
        /// <returns></returns>
        public string Delete(string t_id)
        {
            if (string.IsNullOrEmpty(t_id)) { return "Error:10001"; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("t_id", t_id));

            string Result = base.SyncRequest(TypeOption.MD_TASK_DELETE, Query, null);
            return Result;
        }
    }
}
