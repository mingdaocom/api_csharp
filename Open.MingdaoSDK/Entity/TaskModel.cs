using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Open.MingdaoSDK.Entity
{
    [Serializable]
    [XmlRoot("result")]
    public class TaskResultModel
    {
        private Collection<TaskModel> tasks = new Collection<TaskModel>();
        [XmlElement("task")]
        public Collection<TaskModel> Tasks
        {
            get { return tasks; }
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
    [XmlRoot("task")]
    public class TaskModel
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
        private string _title;
        [XmlElement("title")]
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _expire_date;
        [XmlElement("expire_date")]
        public string expire_date
        {
            get { return _expire_date; }
            set { _expire_date = value; }
        }
        private string _finished_date;
        [XmlElement("finished_date")]
        public string finished_date
        {
            get { return _finished_date; }
            set { _finished_date = value; }
        }
        private string _create_time;
        [XmlElement("create_time")]
        public string create_time
        {
            get { return _create_time; }
            set { _create_time = value; }
        }
        private string _unread_count;
        [XmlElement("unread_count")]
        public string unread_count
        {
            get { return _unread_count; }
            set { _unread_count = value; }
        }
        private string _reply_count;
        [XmlElement("reply_count")]
        public string reply_count
        {
            get { return _reply_count; }
            set { _reply_count = value; }
        }
        private TaskDetailUsers _RUser;
        [XmlElement("user")]
        public TaskDetailUsers RUser
        {
            get { return _RUser; }
            set { _RUser = value; }
        }
    }
}
