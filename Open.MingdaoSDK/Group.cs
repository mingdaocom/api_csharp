using System;
using System.Collections.Generic;
using System.Text;
using Open.MingdaoSDK.Common;
using Open.MingdaoSDK.Entity;
using System.Collections.Specialized;

namespace Open.MingdaoSDK
{
    public class Group : MDAPIBase
    {
        public Group(Parameter u_key) : base(u_key) { }

        /// <summary>
        ///获取企业所有的群组
        /// </summary>
        /// <param name="keywords">关键词模糊搜索，当为空时则返回所有的动态更新</param>
        /// <returns></returns>
        public GroupListModel GetAllGroup(string keywords)
        {
            List<Parameter> Que = new List<Parameter>();
            if (!string.IsNullOrEmpty(keywords))
            {
                Que.Add(new Parameter("keywords", keywords));
            }
            string ResultList = base.SyncRequest(TypeOption.MD_GROUP_ALL, Que, null);
            if (!string.IsNullOrEmpty(ResultList))
            {
                return XmlSerializationHelper.XmlToObject<GroupListModel>(ResultList);
            }
            return null;
        }
        /// <summary>
        ///获取当前登录用户创建的群组
        /// </summary>
        /// <returns></returns>
        public GroupListModel GetMyGroups()
        {
            string Result = base.SyncRequest(TypeOption.MD_GROUP_MYCREATED, null, null);
            if (!string.IsNullOrEmpty(Result))
            {
                return XmlSerializationHelper.XmlToObject<GroupListModel>(Result);
            }
            return null;
        }
        /// <summary>
        /// 获取当前用户加入的群组 
        /// </summary>
        /// <returns></returns>
        public GroupListModel GetJoinedGroups()
        {
            string Result = base.SyncRequest(TypeOption.MD_GROUP_MYJOINED, null, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<GroupListModel>(Result);

            return null;
        }
        /// <summary>
        /// 获取群组成员的用户信息
        /// </summary>
        /// <param name="GroupID">群组编号</param>
        /// <returns></returns>
        public UserListModel GetUsersByGroup(string GroupID)
        {
            UserListModel users=new UserListModel ();
            users.Error_Code="10001";
            if (string.IsNullOrEmpty(GroupID)) { return users; }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("g_id", GroupID));
            string ResultList = base.SyncRequest(TypeOption.MD_GROUP_USER, Que, null);
            if (!string.IsNullOrEmpty(ResultList))
                return XmlSerializationHelper.XmlToObject<UserListModel>(ResultList);

            return null;
        }
        /// <summary>
        /// 创建一个群组
        /// </summary>
        /// <param name="gname">要创建的群组的名称</param>
        /// <param name="ispublic">是否公开群组，“0”表示私有群组，1表示公开群组</param>
        /// <returns></returns>
        public GroupListModel Create(string gname, string ispublic)
        {
            GroupListModel Group = new GroupListModel();
            Group.Error_Code = "10001";
            if (string.IsNullOrEmpty(gname))
            {
                return Group;
            }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("g_name", gname));
            if (!string.IsNullOrEmpty(ispublic))
            {
                Que.Add(new Parameter("is_public", ispublic));
            }
            string Result = base.SyncRequest(TypeOption.MD_GROUP_CREATE, Que, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<GroupListModel>(Result);

            return null;
        }
        /// <summary>
        /// 退出群组
        /// </summary>
        /// <param name="gid">群组编号</param>
        /// <returns></returns>
        public string Exit(string gid)
        {
            if (string.IsNullOrEmpty(gid)) { return "Error:群组ID不能为空！"; }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("g_id", gid));
            string Result = base.SyncRequest(TypeOption.MD_GROUP_EXIT, Que, null);
            return Result;
        }
        /// <summary>
        /// 加入群组
        /// </summary>
        /// <param name="gid">群组编号</param>
        /// <returns></returns>
        public string Join(string gid)
        {
            if (string.IsNullOrEmpty(gid)) { return "Error:群组ID不能为空！"; }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("g_id", gid));
            string Result = base.SyncRequest(TypeOption.MD_GROUP_JOIN, Que, null);
            return Result;
        }
        /// <summary>
        /// 关闭群组
        /// </summary>
        /// <param name="gid">群组编号</param>
        /// <returns></returns>
        public string Close(string gid)
        {
            if (string.IsNullOrEmpty(gid)) { return "Error:群组ID不能为空！"; }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("g_id", gid));
            string Result = base.SyncRequest(TypeOption.MD_GROUP_CLOSE, Que, null);
            return Result;
        }
        /// <summary>
        /// 开启群组
        /// </summary>
        /// <param name="gid">群组编号</param>
        /// <returns></returns>
        public string Open(string gid)
        {
            if (string.IsNullOrEmpty(gid)) { return "Error:群组ID不能为空！"; }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("g_id", gid));
            string Result = base.SyncRequest(TypeOption.MD_GROUP_OPEN, Que, null);
            return Result;
        }
        /// <summary>
        /// 删除群组
        /// </summary>
        /// <param name="gid">群组编号</param>
        /// <returns></returns>
        public string Delete(string gid)
        {
            if (string.IsNullOrEmpty(gid)) { return "Error:群组ID不能为空！"; }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("g_id", gid));
            string Result = base.SyncRequest(TypeOption.MD_GROUP_DELETE, Que, null);
            return Result;
        }
        /// <summary>
        /// 邀请用户（同事邮箱）加入群组
        /// </summary>
        /// <param name="gid">群组编号</param>
        /// <param name="email">被邀请人的邮箱</param>
        /// <returns></returns>
        public string InviteJoinGroup(string gid, string email)
        {
            if (string.IsNullOrEmpty(gid) || string.IsNullOrEmpty(email)) { return "Error:10001"; }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("g_id", gid));
            Que.Add(new Parameter("email", email));
            string Result = base.SyncRequest(TypeOption.MD_GROUP_INVITE, Que, null);
            return Result;
        }
    }
}
