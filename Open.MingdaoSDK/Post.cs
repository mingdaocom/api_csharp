using System;
using System.Collections.Generic;
using System.Text;
using Open.MingdaoSDK.Entity;
using Open.MingdaoSDK.Common;
using System.Collections.Specialized;

namespace Open.MingdaoSDK
{
    public class Post : MDAPIBase
    {
        public Post(Parameter u_key) : base(u_key) { }
        /// <summary>
        ///获取当前登录用户及其所关注用户的动态更新 
        /// </summary>
        /// <param name="Keywords">关键词模糊搜索，当为空时则返回所有的动态更新</param>
        /// <param name="SinceId">若指定此参数，则只返回ID比since_id大的动态更新（即比since_id发表时间晚的动态更新）</param>
        /// <param name="MaxId">若指定此参数，则只返回ID比max_id小的动态更新（即比max_id发表时间早的动态更新）</param>
        /// <param name="PageSize">指定要返回的记录条数</param>
        /// <returns></returns>
        public PostResultModel Followed(string Keywords, string SinceId, string MaxId, string PageSize)
        {
            List<Parameter> Query = new List<Parameter>();
            if (!string.IsNullOrEmpty(Keywords))
                Query.Add(new Parameter("keywords", Keywords));
            if (!string.IsNullOrEmpty(SinceId))
                Query.Add(new Parameter("since_id", SinceId));
            if (!string.IsNullOrEmpty(MaxId))
                Query.Add(new Parameter("max_id", MaxId));
            if (!string.IsNullOrEmpty(PageSize))
                Query.Add(new Parameter("pagesize", PageSize));

            string Result = base.SyncRequest(TypeOption.MD_POST_FOLLOWED, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<PostResultModel>(Result);

            return null;
        }
        /// <summary>
        ///获取全公司的动态更新
        /// </summary>
        /// <param name="Keywords">关键词模糊搜索，当为空时则返回所有的动态更新</param>
        /// <param name="SinceId">若指定此参数，则只返回ID比since_id大的动态更新（即比since_id发表时间晚的动态更新）</param>
        /// <param name="MaxId">若指定此参数，则只返回ID比max_id小的动态更新（即比max_id发表时间早的动态更新）</param>
        /// <param name="PageSize">指定要返回的记录条数</param>
        /// <returns></returns>
        public PostResultModel GetAll(string Keywords, string SinceId, string MaxId, string PageSize)
        {
            List<Parameter> Query = new List<Parameter>();
            if (!string.IsNullOrEmpty(Keywords))
                Query.Add(new Parameter("keywords", Keywords));
            if (!string.IsNullOrEmpty(SinceId))
                Query.Add(new Parameter("since_id", SinceId));
            if (!string.IsNullOrEmpty(MaxId))
                Query.Add(new Parameter("max_id", MaxId));
            if (!string.IsNullOrEmpty(PageSize))
                Query.Add(new Parameter("pagesize", PageSize));

            string Result = base.SyncRequest(TypeOption.MD_POST_ALL, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<PostResultModel>(Result);

            return null;
        }
        /// <summary>
        ///获取当前登录用户发布的动态更新
        /// </summary>
        /// <param name="Keywords">关键词模糊搜索，当为空时则返回所有的动态更新</param>
        /// <param name="SinceId">若指定此参数，则只返回ID比since_id大的动态更新（即比since_id发表时间晚的动态更新）</param>
        /// <param name="MaxId">若指定此参数，则只返回ID比max_id小的动态更新（即比max_id发表时间早的动态更新）</param>
        /// <param name="PageSize">指定要返回的记录条数</param>
        /// <returns></returns>
        public PostResultModel GetMy(string Keywords, string SinceId, string MaxId, string PageSize)
        {
            List<Parameter> Query = new List<Parameter>();
            if (!string.IsNullOrEmpty(Keywords))
                Query.Add(new Parameter("keywords", Keywords));
            if (!string.IsNullOrEmpty(SinceId))
                Query.Add(new Parameter("since_id", SinceId));
            if (!string.IsNullOrEmpty(MaxId))
                Query.Add(new Parameter("max_id", MaxId));
            if (!string.IsNullOrEmpty(PageSize))
                Query.Add(new Parameter("pagesize", PageSize));

            string Result = base.SyncRequest(TypeOption.MD_POST_MY, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<PostResultModel>(Result);

            return null;
        }
        /// <summary>
        ///获取提及@我的动态更新
        /// </summary>
        /// <param name="Keywords">关键词模糊搜索，当为空时则返回所有的动态更新</param>
        /// <param name="SinceId">若指定此参数，则只返回ID比since_id大的动态更新（即比since_id发表时间晚的动态更新）</param>
        /// <param name="MaxId">若指定此参数，则只返回ID比max_id小的动态更新（即比max_id发表时间早的动态更新）</param>
        /// <param name="PageSize">指定要返回的记录条数</param>
        /// <returns></returns>
        public PostResultModel AtMe(string Keywords, string SinceId, string MaxId, string PageSize)
        {
            List<Parameter> Query = new List<Parameter>();
            if (!string.IsNullOrEmpty(Keywords))
                Query.Add(new Parameter("keywords", Keywords));
            if (!string.IsNullOrEmpty(SinceId))
                Query.Add(new Parameter("since_id", SinceId));
            if (!string.IsNullOrEmpty(MaxId))
                Query.Add(new Parameter("max_id", MaxId));
            if (!string.IsNullOrEmpty(PageSize))
                Query.Add(new Parameter("pagesize", PageSize));

            string Result = base.SyncRequest(TypeOption.MD_POST_ATME, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<PostResultModel>(Result);

            return null;
        }
        /// <summary>
        ///获取回复我的最新回复信息
        /// </summary>
        /// <param name="Keywords">关键词模糊搜索，当为空时则返回所有的动态更新</param>
        /// <param name="SinceId">若指定此参数，则只返回ID比since_id大的动态更新（即比since_id发表时间晚的动态更新）</param>
        /// <param name="MaxId">若指定此参数，则只返回ID比max_id小的动态更新（即比max_id发表时间早的动态更新）</param>
        /// <param name="PageSize">指定要返回的记录条数</param>
        /// <returns></returns>
        public ReplymentMeResultModel ReplyMe(string Keywords, string SinceId, string MaxId, string PageSize)
        {
            List<Parameter> Query = new List<Parameter>();
            if (!string.IsNullOrEmpty(Keywords))
                Query.Add(new Parameter("keywords", Keywords));
            if (!string.IsNullOrEmpty(SinceId))
                Query.Add(new Parameter("since_id", SinceId));
            if (!string.IsNullOrEmpty(MaxId))
                Query.Add(new Parameter("max_id", MaxId));
            if (!string.IsNullOrEmpty(PageSize))
                Query.Add(new Parameter("pagesize", PageSize));

            string Result = base.SyncRequest(TypeOption.MD_POST_REPLYME, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<ReplymentMeResultModel>(Result);

            return null;
        }
        /// <summary>
        ///获取当前登录用户收藏的动态更新
        /// </summary>
        /// <param name="Keywords">关键词模糊搜索，当为空时则返回所有的动态更新</param>
        /// <param name="SinceId">若指定此参数，则只返回ID比since_id大的动态更新（即比since_id发表时间晚的动态更新）</param>
        /// <param name="MaxId">若指定此参数，则只返回ID比max_id小的动态更新（即比max_id发表时间早的动态更新）</param>
        /// <param name="PageSize">指定要返回的记录条数</param>
        /// <returns></returns>
        public PostResultModel Favorite(string Keywords, string SinceId, string MaxId, string PageSize)
        {
            List<Parameter> Query = new List<Parameter>();
            if (!string.IsNullOrEmpty(Keywords))
                Query.Add(new Parameter("keywords", Keywords));
            if (!string.IsNullOrEmpty(SinceId))
                Query.Add(new Parameter("since_id", SinceId));
            if (!string.IsNullOrEmpty(MaxId))
                Query.Add(new Parameter("max_id", MaxId));
            if (!string.IsNullOrEmpty(PageSize))
                Query.Add(new Parameter("pagesize", PageSize));

            string Result = base.SyncRequest(TypeOption.MD_POST_FAVORITE, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<PostResultModel>(Result);

            return null;
        }
        /// <summary>
        ///获取群组的动态更新
        /// </summary>
        /// <param name="GroupID">群组编号</param>
        /// <param name="Keywords">关键词模糊搜索，当为空时则返回所有的动态更新</param>
        /// <param name="SinceId">若指定此参数，则只返回ID比since_id大的动态更新（即比since_id发表时间晚的动态更新）</param>
        /// <param name="MaxId">若指定此参数，则只返回ID比max_id小的动态更新（即比max_id发表时间早的动态更新）</param>
        /// <param name="PageSize">指定要返回的记录条数</param>
        /// <returns></returns>
        public PostResultModel GetDynamicInfoByGroup(string GroupID, string Keywords, string SinceId, string MaxId, string PageSize)
        {
            PostResultModel post = new PostResultModel();
            post.Error_Code = "10001";
            if (string.IsNullOrEmpty(GroupID)) { return post; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("g_id", GroupID));
            if (!string.IsNullOrEmpty(Keywords))
                Query.Add(new Parameter("keywords", Keywords));
            if (!string.IsNullOrEmpty(SinceId))
                Query.Add(new Parameter("since_id", SinceId));
            if (!string.IsNullOrEmpty(MaxId))
                Query.Add(new Parameter("max_id", MaxId));
            if (!string.IsNullOrEmpty(PageSize))
                Query.Add(new Parameter("pagesize", PageSize));

            string Result = base.SyncRequest(TypeOption.MD_POST_GROUP, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<PostResultModel>(Result);

            return null;
        }
        /// <summary>
        ///获取用户发布的动态更新
        /// </summary>
        /// <param name="UserID">用户编号</param>
        /// <param name="SinceId">若指定此参数，则只返回ID比since_id大的动态更新（即比since_id发表时间晚的动态更新）</param>
        /// <param name="MaxId">若指定此参数，则只返回ID比max_id小的动态更新（即比max_id发表时间早的动态更新）</param>
        /// <param name="PageSize">指定要返回的记录条数</param>
        /// <returns></returns>
        public PostResultModel GetDynamicInfoByUser(string UserID, string SinceId, string MaxId, string PageSize)
        {
            PostResultModel post=new PostResultModel ();
            post.Error_Code = "10001";
            if (string.IsNullOrEmpty(UserID)) { return post; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("u_id", UserID));
            if (!string.IsNullOrEmpty(SinceId))
                Query.Add(new Parameter("since_id", SinceId));
            if (!string.IsNullOrEmpty(MaxId))
                Query.Add(new Parameter("max_id", MaxId));
            if (!string.IsNullOrEmpty(PageSize))
                Query.Add(new Parameter("pagesize", PageSize));

            string Result = base.SyncRequest(TypeOption.MD_POST_USER, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<PostResultModel>(Result);

            return null;
        }
        /// <summary>
        ///获取文档列表更新
        /// </summary>
        /// <param name="GroupID">群组编号</param>
        /// <param name="Keywords">关键词模糊搜索，当为空时则返回所有的动态更新</param>
        /// <param name="SinceId">若指定此参数，则只返回ID比since_id大的动态更新（即比since_id发表时间晚的动态更新）</param>
        /// <param name="MaxId">若指定此参数，则只返回ID比max_id小的动态更新（即比max_id发表时间早的动态更新）</param>
        /// <param name="PageSize">指定要返回的记录条数</param>
        /// <returns></returns>
        public PostDocResultModel GetDocListInfo(string GroupID, string Keywords, string SinceId, string MaxId, string PageSize)
        {
            List<Parameter> Query = new List<Parameter>();
            if (!string.IsNullOrEmpty(GroupID))
                Query.Add(new Parameter("g_id", GroupID));
            if (!string.IsNullOrEmpty(Keywords))
                Query.Add(new Parameter("keywords", Keywords));
            if (!string.IsNullOrEmpty(SinceId))
                Query.Add(new Parameter("since_id", SinceId));
            if (!string.IsNullOrEmpty(MaxId))
                Query.Add(new Parameter("max_id", MaxId));
            if (!string.IsNullOrEmpty(PageSize))
                Query.Add(new Parameter("pagesize", PageSize));

            string Result = base.SyncRequest(TypeOption.MD_POST_DOC, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<PostDocResultModel>(Result);

            return null;
        }
        /// <summary>
        ///获取图片列表的动态更新
        /// </summary>
        /// <param name="GroupID">用户编号</param>
        /// <param name="SinceId">若指定此参数，则只返回ID比since_id大的动态更新（即比since_id发表时间晚的动态更新）</param>
        /// <param name="MaxId">若指定此参数，则只返回ID比max_id小的动态更新（即比max_id发表时间早的动态更新）</param>
        /// <param name="PageSize">指定要返回的记录条数</param>
        /// <returns></returns>
        public PostResultModel GetImgListInfo(string GroupID, string SinceId, string MaxId, string PageSize)
        {
            List<Parameter> Query = new List<Parameter>();
            if (!string.IsNullOrEmpty(GroupID))
                Query.Add(new Parameter("g_id", GroupID));
            if (!string.IsNullOrEmpty(SinceId))
                Query.Add(new Parameter("since_id", SinceId));
            if (!string.IsNullOrEmpty(MaxId))
                Query.Add(new Parameter("max_id", MaxId));
            if (!string.IsNullOrEmpty(PageSize))
                Query.Add(new Parameter("pagesize", PageSize));

            string Result = base.SyncRequest(TypeOption.MD_POST_IMG, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<PostResultModel>(Result);

            return null;
        }
        /// <summary>
        /// 获取问答列表信息
        /// </summary>
        /// <param name="GroupID">群组编号</param>
        /// <param name="SinceId">若指定此参数，则只返回ID比since_id大的动态更新（即比since_id发表时间晚的动态更新）</param>
        /// <param name="MaxId">若指定此参数，则只返回ID比max_id小的动态更新（即比max_id发表时间早的动态更新）</param>
        /// <param name="PageSize">指定要返回的记录条数</param>
        /// <returns></returns>
        public PostFAQResultModel GetFAQInfo(string GroupID, string SinceId, string MaxId, string PageSize)
        {
            List<Parameter> Query = new List<Parameter>();
            if (!string.IsNullOrEmpty(GroupID))
                Query.Add(new Parameter("g_id", GroupID));
            if (!string.IsNullOrEmpty(SinceId))
                Query.Add(new Parameter("since_id", SinceId));
            if (!string.IsNullOrEmpty(MaxId))
                Query.Add(new Parameter("max_id", MaxId));
            if (!string.IsNullOrEmpty(PageSize))
                Query.Add(new Parameter("pagesize", PageSize));

            string Result = base.SyncRequest(TypeOption.MD_POST_FAQ, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<PostFAQResultModel>(Result);

            return null;
        }
        /// <summary>
        /// 获取当前登录用户未读动态更新数量
        /// </summary>
        /// <returns></returns>
        public string GetUnreadCount()
        {
            string Result = base.SyncRequest(TypeOption.MD_POST_UNREADCOUNT, null, null);
            return Result;
        }
        /// <summary>
        ///根据动态更新编号获取单条动态更新内容
        /// </summary>
        /// <param name="ID">动态更新编号</param>
        /// <returns></returns>
        public PostResultModel GetPostDetailByID(string ID)
        {
            PostResultModel post=new PostResultModel ();
            post.Error_Code="10001";
            if (string.IsNullOrEmpty(ID)) { return post; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("p_id", ID));

            string Result = base.SyncRequest(TypeOption.MD_POST_DETAIL, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<PostResultModel>(Result);

            return null;
        }
        /// <summary>
        /// 根据动态更新编号获取某条动态更新的回复列表信息
        /// </summary>
        /// <param name="ID">动态更新编号</param>
        /// <returns></returns>
        public PostReplymentResultModel GetPostReplyByID(string ID)
        {
            PostReplymentResultModel postreply=new PostReplymentResultModel ();
            postreply.Error_Code="10001";
            if (string.IsNullOrEmpty(ID)) { return postreply; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("p_id", ID));

            string Result = base.SyncRequest(TypeOption.MD_POST_REPLY, Query, null);
            if (!string.IsNullOrEmpty(Result))
                return XmlSerializationHelper.XmlToObject<PostReplymentResultModel>(Result);

            return null;
        }
        /// <summary>
        /// 发布一条动态更新
        /// </summary>
        /// <param name="GroupID">可为空，动态接受对象（群组编号）</param>
        /// <param name="PMsg">动态更新内容</param>
        /// <param name="SType">分享范围(-1表示系统分享；2表示群内分享；3表示分享给自己；其他表示分享给关注的人)</param>
        /// <returns></returns>
        public string Update(string GroupID, string PMsg, string SType)
        {
            if (string.IsNullOrEmpty(PMsg)) { return "Error:10001"; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("p_msg", PMsg));
            if (!string.IsNullOrEmpty(GroupID))
                Query.Add(new Parameter("g_id", GroupID));
            if (!string.IsNullOrEmpty(SType))
                Query.Add(new Parameter("s_type", SType));

            string Result = base.SyncRequest(TypeOption.MD_POST_UPDATE, Query, null);

            return Result;
        }
        /// <summary>
        /// 上传图片并发布一条动态更新
        /// </summary>
        /// <param name="GroupID">可为空，动态接受对象（群组编号）</param>
        /// <param name="PMsg">动态更新内容</param>
        /// <param name="PImg">要上传的图片。仅支持JPEG,GIF,PNG图片,目前上传图片大小限制为<5M。</param>
        /// <param name="IsCenter">是否加入中心</param>
        /// <param name="SType">分享范围</param>
        /// <returns></returns>
        public string Upload(string GroupID, string PMsg, string PImg, string IsCenter, string SType)
        {

            if (string.IsNullOrEmpty(PMsg) || string.IsNullOrEmpty(PImg)) { return "Error:10001"; }
            List<Parameter> Query = new List<Parameter>();
            List<Parameter> Files = new List<Parameter>();
            Query.Add(new Parameter("p_msg", PMsg));
            Files.Add(new Parameter("p_img", PImg));
            if (!string.IsNullOrEmpty(GroupID))
                Query.Add(new Parameter("g_id", GroupID));
            if (!string.IsNullOrEmpty(IsCenter))
                Query.Add(new Parameter("is_center", IsCenter));
            if (!string.IsNullOrEmpty(SType))
                Query.Add(new Parameter("s_type", SType));

            string Result = base.SyncRequest(TypeOption.MD_POST_UPLOAD, Query, Files);

            return Result;
        }
        /// 根据动态更新编号删除一条动态更新
        /// </summary>
        /// <param name="ID">动态更新编号（必须是当前登录用户自己创建的动态更新）</param>
        /// <returns></returns>
        public string Delete(string ID)
        {
            if (string.IsNullOrEmpty(ID)) { return "Error = 10001"; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("p_id", ID));

            string Result = base.SyncRequest(TypeOption.MD_POST_DELETE, Query, null);

            return Result;
        }
        /// <summary>
        /// 转发一条动态更新
        /// </summary>
        /// <param name="GroupID">可为空，动态接受对象（群组编号）</param>
        /// <param name="PMsg">动态更新内容</param>
        /// <param name="ReplyID">待转发的动态更新编号</param>
        /// <returns></returns>
        public string Repost(string GroupID, string PMsg, string ReplyID)
        {
            if (string.IsNullOrEmpty(PMsg) || string.IsNullOrEmpty(ReplyID)) { return "Error:10001"; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("p_msg", PMsg));
            Query.Add(new Parameter("re_p_id", ReplyID));
            if (!string.IsNullOrEmpty(GroupID))
                Query.Add(new Parameter("g_id", GroupID));

            string Result = base.SyncRequest(TypeOption.MD_POST_REPOST, Query, null);

            return Result;
        }
        /// <summary>
        /// 增加一条动态更新的回复
        /// </summary>
        /// <param name="PID">回复的动态更新编号</param>
        /// <param name="ReplyID">回复编号（可以对别人的回复进行回复）[可选]</param>
        /// <param name="RMeg">回复的消息内容</param>
        /// <returns></returns>
        public string AddReply(string PID, string ReplyID, string RMeg)
        {
            if (string.IsNullOrEmpty(PID) || string.IsNullOrEmpty(RMeg)) { return "Error:10001"; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("p_id", PID));
            Query.Add(new Parameter("r_msg", RMeg));
            if (!string.IsNullOrEmpty(ReplyID))
                Query.Add(new Parameter("r_id", ReplyID));

            string Result = base.SyncRequest(TypeOption.MD_POST_ADDREPLY, Query, null);

            return Result;
        }
        /// <summary>
        ///根据回复编号删除一条回复
        /// </summary>
        /// <param name="PID">动态更新编号</param>
        /// <param name="ReplyID">回复编号（必须是当前登录用户自己创建的回复）</param>
        /// <returns></returns>
        public string DeleteReply(string PID, string ReplyID)
        {
            if (string.IsNullOrEmpty(PID) || string.IsNullOrEmpty(ReplyID)) { return "Error:10001"; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("p_id", PID));
            Query.Add(new Parameter("r_id", ReplyID));

            string Result = base.SyncRequest(TypeOption.MD_POST_DELETEREPLY, Query, null);

            return Result;
        }
        /// <summary>
        /// 增加当前登录用户的一条动态更新收藏
        /// </summary>
        /// <param name="PID">动态更新编号</param>
        /// <returns></returns>
        public string AddFavorite(string PID)
        {
            if (string.IsNullOrEmpty(PID)) { return "Error:10001"; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("p_id", PID));

            string Result = base.SyncRequest(TypeOption.MD_POST_ADDFAVORITE, Query, null);

            return Result;
        }
        /// <summary>
        ///删除当前登录用户收藏的一条动态更新
        /// </summary>
        /// <param name="PID">动态更新编号</param>
        /// <returns></returns>
        public string DelFavorite(string PID)
        {
            if (string.IsNullOrEmpty(PID)) { return "Error:10001"; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("p_id", PID));

            string Result = base.SyncRequest(TypeOption.MD_POST_DELETEFAVORITE, Query, null);

            return Result;
        }
        /// <summary>
        /// 删除当前登录用户收藏的一条动态喜欢
        /// </summary>
        /// <param name="PID">动态更新编号</param>
        /// <returns></returns>
        public string DelLike(string PID)
        {
            if (string.IsNullOrEmpty(PID)) { return "Error:10001"; }
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("p_id", PID));

            string Result = base.SyncRequest(TypeOption.MD_POST_DELETELIKE, Query, null);

            return Result;
        }
    }
}
