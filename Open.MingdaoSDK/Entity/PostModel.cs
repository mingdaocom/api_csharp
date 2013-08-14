using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Collections;
using System.Collections.ObjectModel;

namespace Open.MingdaoSDK.Entity
{
    [Serializable]
    [XmlRoot("result")]
    public class PostResultModel
    {
        private Collection<PostModel> posts = new Collection<PostModel>();
        [XmlElement("post")]
        public Collection<PostModel> Posts
        {
            get { return posts; }
        }
        private string _more;
        [XmlElement("more")]
        public string more
        {
            get { return _more; }
            set { _more = value; }
        }
        private string _sincepostid;
        [XmlElement("sincepostid")]
        public string sincepostid
        {
            get { return _sincepostid; }
            set { _sincepostid = value; }
        }
        private string _Error_Code;
        [XmlElement("error_code")]
        public string Error_Code
        {
            get { return _Error_Code; }
            set { _Error_Code = value; }
        }
    }
    [Serializable]
    [XmlRoot("post")]
    public class PostModel
    {
        private string _id;
        [XmlElement("id")]
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _guid;
        [XmlElement("guid")]
        public string guid
        {
            get { return _guid; }
            set { _guid = value; }
        }
        private string _text;
        [XmlElement("text")]
        public string text
        {
            get { return _text; }
            set { _text = value; }
        }
        private string _create_time;
        [XmlElement("create_time")]
        public string create_time
        {
            get { return _create_time; }
            set { _create_time = value; }
        }
        private string _source;
        [XmlElement("source")]
        public string source
        {
            get { return _source; }
            set { _source = value; }
        }
        private string _reply_count;
        [XmlElement("reply_count")]
        public string reply_count
        {
            get { return _reply_count; }
            set { _reply_count = value; }
        }
        private string _like_count;
        [XmlElement("like_count")]
        public string like_count
        {
            get { return _like_count; }
            set { _like_count = value; }
        }
        private string _favorite;
        [XmlElement("favorite")]
        public string favorite
        {
            get { return _favorite; }
            set { _favorite = value; }
        }
        private string _like;
        [XmlElement("like")]
        public string like
        {
            get { return _like; }
            set { _like = value; }
        }
        private string _type;
        [XmlElement("type")]
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _share_type;
        [XmlElement("share_type")]
        public string share_type
        {
            get { return _share_type; }
            set { _share_type = value; }
        }
        private PostDetail _postdetail;
        [XmlElement("detail")]
        public PostDetail postdetail
        {
            get { return _postdetail; }
            set { _postdetail = value; }
        }
        private Collection<PostGroupModel> _postgroup = new Collection<PostGroupModel>();
        [XmlElement("group")]
        public Collection<PostGroupModel> postgroup
        {
            get { return _postgroup; }
        }
        private TaskDetailUsers _postuser;
        [XmlElement("user")]
        public TaskDetailUsers postuser
        {
            get { return _postuser; }
            set { _postuser = value; }
        }
        private PostModel _reportpost;
        [XmlElement("repost")]
        public PostModel reportpost
        {
            get { return _reportpost; }
            set { _reportpost = value; }
        }
    }
    [Serializable]
    [XmlRoot("detail")]
    public class PostDetail
    {
        private string _post_guid;
        [XmlElement("post_guid")]
        public string post_guid
        {
            get { return _post_guid; }
            set { _post_guid = value; }
        }
        private string _link_url;
        [XmlElement("link_url")]
        public string link_url
        {
            get { return _link_url; }
            set { _link_url = value; }
        }
        private string _link_title;
        [XmlElement("link_title")]
        public string link_title
        {
            get { return _link_title; }
            set { _link_title = value; }
        }
        private string _link_des;
        [XmlElement("link_des")]
        public string link_des
        {
            get { return _link_des; }
            set { _link_des = value; }
        }
        private string _thumbnail_pic;
        [XmlElement("thumbnail_pic")]
        public string thumbnail_pic
        {
            get { return _thumbnail_pic; }
            set { _thumbnail_pic = value; }
        }
        private string _original_pic;
        [XmlElement("original_pic")]
        public string original_pic
        {
            get { return _original_pic; }
            set { _original_pic = value; }
        }

    }
}
