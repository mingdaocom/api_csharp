using System;
using System.Collections.Generic;
using System.Text;

namespace Open.MingdaoSDK.Common
{
    /// <summary>
    /// <para>枚举类型，标识请求类型</para>
    /// <para>https://api.open.mingdao.com/</para>
    /// </summary>
    public enum HttpMethod
    {
        GET = 0,
        POST,
        DELETE,
        Other
    }
    /// <summary>
    /// <para>枚举类型，URI标识请求类型</para>
    /// <para>https://api.open.mingdao.com/</para>
    /// </summary>
    public enum TypeOption : int
    {
        MD_Base = 0,
        //动态更新
        MD_POST_FOLLOWED,
        MD_POST_ALL,
        MD_POST_MY,
        MD_POST_ATME,
        MD_POST_REPLYME,
        MD_POST_FAVORITE,
        MD_POST_GROUP,
        MD_POST_USER,
        MD_POST_DOC,
        MD_POST_IMG,
        MD_POST_FAQ,
        MD_POST_UNREADCOUNT,
        MD_POST_DETAIL,
        MD_POST_REPLY,
        MD_POST_UPDATE,
        MD_POST_UPLOAD,
        MD_POST_DELETE,
        MD_POST_REPOST,
        MD_POST_ADDREPLY,
        MD_POST_DELETEREPLY,
        MD_POST_ADDFAVORITE,
        MD_POST_DELETEFAVORITE,
        MD_POST_DELETELIKE,
        //任务
        MD_TASK_MYJOINED,
        MD_TASK_MYJOINEDFINISHED,
        MD_TASK_MYASSIGN,
        MD_TASK_MYASSIGNFINISHED,
        MD_TASK_MYCHARGE,
        MD_TASK_MYCHARGEFINISHED,
        MD_TASK_PROJECT,
        MD_TASK_UNREADCOUNT,
        MD_TASK_DETAIL,
        MD_TASK_REPLY,
        MD_TASK_CREATE,
        MD_TASK_FINISH,
        MD_TASK_ADDREPLY,
        MD_TASK_DELETE,
        //用户
        MD_USER_ALL,
        MD_USER_SEARCH,
        MD_USER_DETAIL,
        MD_USER_FOLLOWED,
        MD_USER_DEPARTMENT,
        MD_USER_ADDFOLLOWED,
        MD_USER_DELETEFOLLOWED,
        MD_USER_INVITE,
        //群组
        MD_GROUP_ALL,
        MD_GROUP_MYCREATED,
        MD_GROUP_MYJOINED,
        MD_GROUP_USER,
        MD_GROUP_CREATE,
        MD_GROUP_EXIT,
        MD_GROUP_JOIN,
        MD_GROUP_CLOSE,
        MD_GROUP_OPEN,
        MD_GROUP_DELETE,
        MD_GROUP_INVITE,
        //私信
        MD_MESSAGE_ALL,
        MD_MESSAGE_LIST,
        MD_MESSAGE_UNREADCOUNT,
        MD_MESSAGE_CREATE,
        MD_MESSAGE_DELETE,
        MD_MESSAGE_READ,
        //账号
        MD_PASSPORT_DETAIL,
        MD_PASSPORT_EDIT,
        MD_PASSPORT_EDITAVSTAR,
        //登陆验证
        MD_OAUTH2_AUTHORIZE,
        MD_OAUTH2_ACCESSTOKEN,
        MD_OAUTH2_DEVICE,
        //应用版本
        MD_version,

        MD_MAX
    }
    /// <summary>
    /// <para>各个API的URI与TypeOption类型相对应</para>
    /// <para>https://api.open.mingdao.com/</para>
    /// </summary>
     public class APIType
    {
         //正式
        private const string BaseUrl = "https://api.mingdao.com/";
        private static string[] Uri =
        {
            "base",
            //动态更新
            "post/followed",
            "post/all",
            "post/my",
            "post/atme",
            "post/replyme",
            "post/favorite",
            "post/group",
            "post/user",
            "post/doc",
            "post/img",
            "post/faq",
            "post/unreadcount",
            "post/detail",
            "post/reply",
            "post/update",
            "post/upload",
            "post/delete",
            "post/repost",
            "post/add_reply",
            "post/delete_reply",
            "post/add_favorite",
            "post/delete_favorite",
            "post/delete_like",
            //任务
            "task/my_joined",
            "task/my_joined_finished",
            "task/my_assign",
            "task/my_assign_finished",
            "task/my_charge",
            "task/my_charge_finished",
            "task/project",
            "task/unreadcount",
            "task/detail",
            "task/reply",
            "task/create",
            "task/finish",
            "task/addreply",
            "task/delete",
            //用户
            "user/all",
            "user/search",
            "user/detail",
            "user/followed",
            "user/department",
            "user/add_followed",
            "user/delete_followed",
            "user/invite",
            //群组
            "group/all",
            "group/my_created",
            "group/my_joined",
            "group/user",
            "group/create",
            "group/exit",
            "group/join",
            "group/close",
            "group/open",
            "group/delete",
            "group/invite",
            //私信
            "message/all",
            "message/list",
            "message/unreadcount",
            "message/create",
            "message/delete",
            "message/read",
            //账号
            "passport/detail",
            "passport/edit",
            "passport/edit_avstar",
            //登陆验证
            "auth2/authorize",
            "auth2/access_token",
            "auth2/device",
            //应用版本
            "version"
        };
        /// <summary>
        /// <para>根据URI类型返回完整URL</para>
        /// <para>https://api.open.mingdao.com/</para>
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        public static string GetURL(TypeOption Type)
        {
            string Whole = string.Empty;
            if (Type <= TypeOption.MD_Base || Type >= TypeOption.MD_MAX) { return Whole; }

            Whole = BaseUrl + Uri[(int)Type];

            return Whole;
        }
        /// <summary>
        /// <para>枚举类型，API请求类型</para>
        /// <para>https://api.open.mingdao.com/</para>
        /// </summary>
        private static HttpMethod[] HMethod =
        {
            HttpMethod.Other,
            //动态更新
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.POST,
            HttpMethod.POST,
            HttpMethod.GET,
            HttpMethod.POST,
            HttpMethod.POST,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            //任务
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.POST,
            HttpMethod.GET,
            HttpMethod.POST,
            HttpMethod.GET,
            //用户
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            //群组
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            //私信
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.POST,
            HttpMethod.GET,
            HttpMethod.GET,
            //账号
            HttpMethod.GET,
            HttpMethod.POST,
            HttpMethod.POST,
            //登陆验证
            HttpMethod.GET,
            HttpMethod.GET,
            HttpMethod.GET,
            //应用版本
            HttpMethod.GET
        };
        public static string GetHttpMethod(TypeOption type)
        {
            return HMethod[(int)type] == HttpMethod.GET ? "GET" : "POST";
        }
    }


}
