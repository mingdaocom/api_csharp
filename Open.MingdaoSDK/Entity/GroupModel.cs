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
    [XmlRoot("group")]
    public class GroupModel
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
        private string _is_public;
        [XmlElement("is_public")]
        public string is_public
        {
            get { return _is_public; }
            set { _is_public = value; }
        }
        private string _status;
        [XmlElement("status")]
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        private string _followed_status;
        [XmlElement("followed_status")]
        public string followed_status
        {
            get { return _followed_status; }
            set { _followed_status = value; }
        }
        private string _user_count;
        [XmlElement("user_count")]
        public string user_count
        {
            get { return _user_count; }
            set { _user_count = value; }
        }
        private string _post_count;
        [XmlElement("post_count")]
        public string post_count
        {
            get { return _post_count; }
            set { _post_count = value; }
        }
        private GroupUser _Guser;
        [XmlElement("user")]
        public GroupUser Guser
        {
            get { return _Guser; }
            set { _Guser = value; }
        }
        private GroupAdminIDs _Admin;
        [XmlElement("admins")]
        public GroupAdminIDs Admin
        {
            get { return _Admin; }
            set { _Admin = value; }
        }
    }
    [Serializable]
    [XmlRoot("result")]
    public class GroupListModel
    {
        private Collection<GroupModel> group = new Collection<GroupModel>();
        [XmlElement("group")]
        public Collection<GroupModel> Group
        {
            get
            {
                return group;
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
    public class GroupUser
    {
        private string _value;
        [XmlElement("id")]
        public string id
        {
            get { return _value; }
            set { _value = value; }
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
    [XmlRoot("admins")]
    public class GroupAdminIDs
    {
        private string _id;
        [XmlElement("id")]
        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
