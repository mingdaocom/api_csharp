using System;
using System.Collections.Generic;
using System.Text;
using Open.MingdaoSDK.Common;
using Open.MingdaoSDK.Entity;
using System.Collections.Specialized;


namespace Open.MingdaoSDK
{
    public class User : MDAPIBase
    {
        public User(Parameter u_Key) : base(u_Key) { }
        /// <summary>
        /// 获取通讯录
        /// </summary>
        /// <returns></returns>
        public UserListModel GetAddressBook()
        {
            string UserList = base.SyncRequest(TypeOption.MD_USER_ALL, null, null);
            if (!string.IsNullOrEmpty(UserList))
            {
                return XmlSerializationHelper.XmlToObject<UserListModel>(UserList);
            }
            return null;
        }
        /// <summary>
        /// 获取用户列表信息
        /// </summary>
        /// <param name="keywords">关键词</param>
        /// <param name="g_id">群组编号</param>
        /// <param name="dep">部门完整名称</param>
        /// <returns></returns>
        public UserListModel GetUser(string keywords, string g_id, string dep)
        {
            UserListModel user=new UserListModel ();
            user.Error_Code="10001";
            if (string.IsNullOrEmpty(keywords) || string.IsNullOrEmpty(g_id) || string.IsNullOrEmpty(dep)) { return user; }
            List<Parameter> Params = new List<Parameter>();
            Params.Add(new Parameter("keywords", keywords));
            Params.Add(new Parameter("g_id", g_id));
            Params.Add(new Parameter("dep", dep));

            string User = base.SyncRequest(TypeOption.MD_USER_SEARCH, Params, null);
            if (!string.IsNullOrEmpty(User))
            {
                return XmlSerializationHelper.XmlToObject<UserListModel>(User);
            }
            return null;
        }
        /// <summary>
        ///  获取用户列表信息
        /// </summary>
        /// <returns></returns>
        public UserListModel GetUser()
        {
            string User = base.SyncRequest(TypeOption.MD_USER_ALL, null, null);
            if (!string.IsNullOrEmpty(User))
            {
                // return XmlSerializationHelper.XmlDeserialize<UserListModel>(User, Encoding.UTF8);
                return XmlSerializationHelper.XmlToObject<UserListModel>(User);
            }
            return null;
        }
        /// <summary>
        /// 获取用户基本资料
        /// </summary>
        /// <param name="UID">要查询的用户编号</param>
        /// <returns></returns>
        public UserInfoModel GetUserDetail(string UID)
        {
            UserInfoModel user=new UserInfoModel ();
            user.Error_Code="10001";
            if (string.IsNullOrEmpty(UID)) { return user; }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("u_id", UID));
            string UDetail = base.SyncRequest(TypeOption.MD_USER_DETAIL, Que, null);
            if (!string.IsNullOrEmpty(UDetail))
            {
                return XmlSerializationHelper.XmlToObject<UserInfoModel>(UDetail);
            }
            return null;
        }
        /// <summary>
        /// 根据用户编号获取用户正在关注用户信息
        /// </summary>
        /// <param name="UID">用户编号</param>
        /// <returns></returns>
        public UserListModel GetUsersByFollowed(string UID)
        {
            UserListModel users=new UserListModel ();
            users.Error_Code="10001";
            if (string.IsNullOrEmpty(UID)) { return users; }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("u_id", UID));
            string UDetail = base.SyncRequest(TypeOption.MD_USER_FOLLOWED, Que, null);
            if (!string.IsNullOrEmpty(UDetail))
            {
                return XmlSerializationHelper.XmlToObject<UserListModel>(UDetail);
            }
            return null;
        }
        /// <summary>
        /// 获取企业所有部门列表信息
        /// </summary>
        /// <returns></returns>
        public UserDepartmentsModel GetDepartmentList()
        {
            string UDetail = base.SyncRequest(TypeOption.MD_USER_DEPARTMENT, null, null);
            if (!string.IsNullOrEmpty(UDetail))
            {
                return XmlSerializationHelper.XmlToObject<UserDepartmentsModel>(UDetail);
            }
            return null;
        }
        /// <summary>
        ///	当前登录用户添加关注关系
        /// </summary>
        /// <param name="UID">需要关注的用户编号</param>
        /// <returns></returns>
        public string AddFollowed(string UID)
        {
            if (string.IsNullOrEmpty(UID)) { return "Error:10001"; }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("u_id", UID));
            string UDetail = base.SyncRequest(TypeOption.MD_USER_ADDFOLLOWED, Que, null);
            return UDetail;
        }
        /// <summary>
        /// 当前登录用户删除关注关系
        /// </summary>
        /// <param name="UID">需要取消关注的用户编号</param>
        /// <returns></returns>
        public string DeleteFollowedByUID(string UID)
        {
            if (string.IsNullOrEmpty(UID)) { return "Error:10001"; }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("u_id", UID));
            string UDetail = base.SyncRequest(TypeOption.MD_USER_DELETEFOLLOWED, Que, null);
            return UDetail;
        }
        /// <summary>
        /// 邀请用户（同事邮箱）加入企业网络
        /// </summary>
        /// <param name="Email">邀请的邮箱</param>
        /// <returns></returns>
        public string InviteOther(string Email)
        {
            if (string.IsNullOrEmpty(Email)) { return "Error:10001"; }
            List<Parameter> Que = new List<Parameter>();
            Que.Add(new Parameter("email", Email));
            string UDetail = base.SyncRequest(TypeOption.MD_USER_INVITE, Que, null);

            return UDetail;
        }

    }

}
