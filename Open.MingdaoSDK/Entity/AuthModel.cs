using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;

namespace Open.MingdaoSDK.Entity
{
    [Serializable]
    [XmlRoot("result")]
    public class AuthModel
    {
        private string _access_token;
        [XmlElement("access_token")]
        public string access_token
        {
            get { return _access_token; }
            set { _access_token = value; }
        }
        private string _expires;
        [XmlElement("expires_in")]
        public string expires
        {
            get { return _expires; }
            set { _expires = value; }
        }
        private string _refresh_token;
        [XmlElement("refresh_token")]
        public string refresh_token
        {
            get { return _refresh_token; }
            set { _refresh_token = value; }
        }
        private string _Error_Code;
        [XmlElement("error_code")]
        public string Error_Code
        {
            get { return _Error_Code; }
            set { _Error_Code = value; }
        }
        private string _project;
        [XmlElement("project")]
        public string project
        {
            get { return _project; }
            set { _project = value; }
        }
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
