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
    public class ReplymentMeResultModel
    {
        private Collection<ReplymentMeModel> replyme = new Collection<ReplymentMeModel>();
        [XmlElement("replyment")]
        public Collection<ReplymentMeModel> ReplyME
        {
            get { return replyme; }
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
    public class ReplymentMeModel
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
        private ReplyMeref _replymeref;
        [XmlElement("ref")]
        public ReplyMeref replymeref
        {
            get { return _replymeref; }
            set { _replymeref = value; }
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
    public class ReplyMeref
    {
        private ReplyMePost _post;
        [XmlElement("post")]
        public ReplyMePost post
        {
            get { return _post; }
            set { _post = value; }
        }
        private ReplyMePost _replyment;
        [XmlElement("replyment")]
        public ReplyMePost replyment
        {
            get { return _replyment; }
            set { _replyment = value; }
        }
    }
    [Serializable]
    [XmlRoot("post")]
    public class ReplyMePost
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
    }
}
