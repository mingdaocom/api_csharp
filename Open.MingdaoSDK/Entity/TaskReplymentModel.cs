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
    public class TaskReplymentResultModel
    {
        private Collection<TaskReplymentModel> taskRep = new Collection<TaskReplymentModel>();
        [XmlElement("replyment")]
        public Collection<TaskReplymentModel> TaskRep
        {
            get { return taskRep; }
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
    public class TaskReplymentModel
    {
        private string _autoid;
        [XmlElement("autoid")]
        public string autoid
        {
            get { return _autoid; }
            set { _autoid = value; }
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
        private string _type;
        [XmlElement("type")]
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        private TaskReMentDetail _detail;
        [XmlElement("detail")]
        public TaskReMentDetail detail
        {
            get { return _detail; }
            set { _detail = value; }
        }
        private Ref _refu;
        [XmlElement("ref")]
        public Ref refu
        {
            get { return _refu; }
            set { _refu = value; }
        }
        private TaskDetailUsers _dynamlUser;
        [XmlElement("user")]
        public TaskDetailUsers dynamlUser
        {
            get { return _dynamlUser; }
            set { _dynamlUser = value; }
        }
    }
    [Serializable]
    public class RefUser
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
        private string _avstar;
        [XmlElement("avstar")]
        public string avstar
        {
            get { return _avstar; }
            set { _avstar = value; }
        }
    }
    [Serializable]
    [XmlRoot("ref")]
    public class Ref
    {
        private RefUser _RefUser;
        [XmlElement("user")]
        public RefUser RefUser
        {
            get { return _RefUser; }
            set { _RefUser = value; }
        }
    }
    [Serializable]
    [XmlRoot("detail")]
    public class TaskReMentDetail
    {
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
        private string _original_file;
        [XmlElement("original_file")]
        public string original_file
        {
            get { return _original_file; }
            set { _original_file = value; }
        }
    }
}
