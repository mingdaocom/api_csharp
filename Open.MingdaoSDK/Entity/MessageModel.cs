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
    public class MessageModel
    {
        private string _id;
        [XmlElement("id")]
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _text;
        [XmlElement("text")]
        public string text
        {
            get { return _text; }
            set { _text = value; }
        }
        private string _status;
        [XmlElement("status")]
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        private string _create_time;
        [XmlElement("create_time")]
        public string create_time
        {
            get { return _create_time; }
            set { _create_time = value; }
        }
        private string _create_user;
        [XmlElement("create_user")]
        public string create_user
        {
            get { return _create_user; }
            set { _create_user = value; }
        }
    }
    [Serializable]
    [XmlRoot("result")]
    public class MessageListModel
    {
        private Collection<MessageModel> meg = new Collection<MessageModel>();
        [XmlElement("group")]
        public Collection<MessageModel> Meg
        {
            get
            {
                return meg;
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
}
