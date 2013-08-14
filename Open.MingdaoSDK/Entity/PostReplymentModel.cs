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
    public class PostReplymentResultModel
    {
        private Collection<PostReplymentModel> postreplyment = new Collection<PostReplymentModel>();
        [XmlElement("replyment")]
        public Collection<PostReplymentModel> PostReplyment
        {
            get { return postreplyment; }
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
    [XmlRoot("replyment")]
    public class PostReplymentModel
    {
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
        private PostReplayRefModel _refreply;
        [XmlElement("ref")]
        public PostReplayRefModel refreply
        {
            get { return _refreply; }
            set { _refreply = value; }
        }
        private TaskDetailUsers _Ruser;
        [XmlElement("user")]
        public TaskDetailUsers Ruser
        {
            get { return _Ruser; }
            set { _Ruser = value; }
        }
    }
    [Serializable]
    [XmlRoot("ref")]
    public class PostReplayRefModel
    {
        private ReplayMent _rm;
        [XmlElement("replyment")]
        public ReplayMent rm
        {
            get { return _rm; }
            set { _rm = value; }
        }
    }
    [Serializable]
    [XmlRoot("ref")]
    public class ReplayMent
    {
        private string _guid;
        [XmlElement("guid")]
        public string guid
        {
            get { return _guid; }
            set { _guid = value; }
        }
        private ReplyUser _replyuser;
        [XmlElement("user")]
        public ReplyUser replyuser
        {
            get { return _replyuser; }
            set { _replyuser = value; }
        }
    }
    [Serializable]
    [XmlRoot("user")]
    public class ReplyUser
    {
        private string _id;
        [XmlElement("id")]
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;
        [XmlElement("name")]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
