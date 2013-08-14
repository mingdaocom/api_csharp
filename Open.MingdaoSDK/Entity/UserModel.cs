using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Open.MingdaoSDK.Entity
{
    //用户通讯录
    [Serializable]
    [XmlRoot("result")]
    public class UserListModel
    {
        private Collection<UserModel> items = new Collection<UserModel>();
        [XmlElement("user")]
        public Collection<UserModel> Items
        {
            get
            {
                return items;
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
    public class UserModel
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
        private string _avstar100;
        [XmlElement("avstar100")]
        public string avstar100
        {
            get { return _avstar100; }
            set { _avstar100 = value; }
        }
        private string _email;
        [XmlElement("email")]
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _mobilephone;
        [XmlElement("mobilephone")]
        public string mobilephone
        {
            get { return _mobilephone; }
            set { _mobilephone = value; }
        }
        private string _department;
        [XmlElement("department")]
        public string department
        {
            get { return _department; }
            set { _department = value; }
        }
        private string _job;
        [XmlElement("job")]
        public string job
        {
            get { return _job; }
            set { _job = value; }
        }

    }
    //用户部门
    [Serializable]
    [XmlRoot("result")]
    public class UserDepartmentsModel
    {
        private Collection<UDepartment> items = new Collection<UDepartment>();
        [XmlElement("department")]
        public Collection<UDepartment> Items
        {
            get
            {
                return items;
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
    [XmlRoot("department")]
    public class UDepartment
    {
        private string _name;
        [XmlElement("name")]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
    }

    //用户详细信息
    [Serializable]
    [XmlRoot("result")]
    public class UserInfoModel
    {
        private UserDetailModel _Userdetail;
        [XmlElement("user")]
        public UserDetailModel Userdetail
        {
            get { return _Userdetail; }
            set { _Userdetail = value; }
        }
        private string _Error_Code;
        [XmlElement("error_code")]
        public string Error_Code
        {
            get { return _Error_Code; }
            set { _Error_Code = value; }
        }

        private string _Access_Token;
        [XmlElement("Access_Token")]
        public string Access_Token
        {
            get { return _Access_Token; }
            set { _Access_Token = value; }
        }
    }
    [Serializable]
    [XmlRoot("user")]
    public class UserDetailModel
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
        private string _email;
        [XmlElement("email")]
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _grade;
        [XmlElement("grade")]
        public string grade
        {
            get { return _grade; }
            set { _grade = value; }
        }
        private string _mark;
        [XmlElement("mark")]
        public string mark
        {
            get { return _mark; }
            set { _mark = value; }
        }
        private string _birth;
        [XmlElement("birth")]
        public string birth
        {
            get { return _birth; }
            set { _birth = value; }
        }
        private string _gender;
        [XmlElement("gender")]
        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        private string _company;
        [XmlElement("company")]
        public string company
        {
            get { return _company; }
            set { _company = value; }
        }
        private string _department;
        [XmlElement("department")]
        public string department
        {
            get { return _department; }
            set { _department = value; }
        }
        private string _job;
        [XmlElement("job")]
        public string job
        {
            get { return _job; }
            set { _job = value; }
        }
        private string _mobile_phone;
        [XmlElement("mobile_phone")]
        public string mobile_phone
        {
            get { return _mobile_phone; }
            set { _mobile_phone = value; }
        }
        private string _work_phone;
        [XmlElement("work_phone")]
        public string work_phone
        {
            get { return _work_phone; }
            set { _work_phone = value; }
        }
        private string _followed_status;
        [XmlElement("followed_status")]
        public string followed_status
        {
            get { return _followed_status; }
            set { _followed_status = value; }
        }
        private string _license;
        [XmlElement("license")]
        public string license
        {
            get { return _license; }
            set { _license = value; }
        }

    }
}
