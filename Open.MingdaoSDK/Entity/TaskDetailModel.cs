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
    [XmlRoot("task")]
    public class TaskDetailResultModel
    {
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
        private string _des;
        [XmlElement("des")]
        public string des
        {
            get { return _des; }
            set { _des = value; }
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
        private string _reply_count;
        [XmlElement("reply_count")]
        public string reply_count
        {
            get { return _reply_count; }
            set { _reply_count = value; }
        }
        private string _create_time;
        [XmlElement("create_time")]
        public string create_time
        {
            get { return _create_time; }
            set { _create_time = value; }
        }
        private string _create_userid;
        [XmlElement("create_userid")]
        public string create_userid
        {
            get { return _create_userid; }
            set { _create_userid = value; }
        }
        private TaskDetailUsers _RUser;
        [XmlElement("user")]
        public TaskDetailUsers RUser
        {
            get { return _RUser; }
            set { _RUser = value; }
        }
        private TaskProject pro;
        [XmlElement("project")]
        public TaskProject Pro
        {
            get { return pro; }
            set { pro = value; }
        }
        private Collection<TaskDetailUsers> jonusers = new Collection<TaskDetailUsers>();
        [XmlElement("joined")]
        public Collection<TaskDetailUsers> JonUsers
        {
            get { return jonusers; }
            set { jonusers = value; }
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
    public class TaskProject
    {
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

    }
    [Serializable]
    public class TaskDetailUsers
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

}
