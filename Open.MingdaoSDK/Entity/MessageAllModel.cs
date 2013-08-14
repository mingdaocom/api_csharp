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
    [XmlRoot("message")]
    public class NewMessageModel
    {
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
        private MegUser _user;
        [XmlElement("user")]
        public MegUser user
        {
            get { return _user; }
            set { _user = value; }
        }
    }
    [Serializable]
    [XmlRoot("result")]
    public class NewMessageListModel
    {
        private Collection<NewMessageModel> nmeg = new Collection<NewMessageModel>();
        [XmlElement("message")]
        public Collection<NewMessageModel> newMeg
        {
            get
            {
                return nmeg;
            }
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
    [XmlRoot("user")]
    public class MegUser
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
        private string _department;
        [XmlElement("department")]
        public string department
        {
            get { return _department; }
            set { _department = value; }
        }
        private string _unreadmessage_count;
        [XmlElement("unreadmessage_count")]
        public string unreadmessage_count
        {
            get { return _unreadmessage_count; }
            set { _unreadmessage_count = value; }
        }
        private string _message_count;
        [XmlElement("message_count")]
        public string message_count
        {
            get { return _message_count; }
            set { _message_count = value; }
        }
    }
}
