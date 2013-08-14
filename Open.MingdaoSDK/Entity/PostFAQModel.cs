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
    public class PostFAQResultModel
    {
        private Collection<PostFAQModel> postfaq = new Collection<PostFAQModel>();
        [XmlElement("post")]
        public Collection<PostFAQModel> PostFAQ
        {
            get { return postfaq; }
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
    public class PostFAQModel
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
        private string _type;
        [XmlElement("type")]
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        private FAQDetailModel _deta;
        [XmlElement("detail")]
        public FAQDetailModel deta
        {
            get { return _deta; }
            set { _deta = value; }
        }
        private PostGroupModel _group;
        [XmlElement("group")]
        public PostGroupModel group
        {
            get { return _group; }
            set { _group = value; }
        }
        private TaskDetailUsers _Puser;
        [XmlElement("user")]
        public TaskDetailUsers Puser
        {
            get { return _Puser; }
            set { _Puser = value; }
        }
        private PostFAQModel _repost;
        [XmlElement("repost")]
        public PostFAQModel repost
        {
            get { return _repost; }
            set { _repost = value; }
        }
    }
    [Serializable]
    [XmlRoot("detail")]
    public class FAQDetailModel
    {
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
