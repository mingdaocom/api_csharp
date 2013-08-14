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
    public class PostDocResultModel
    {
        private Collection<PostDocModel> post = new Collection<PostDocModel>();
        [XmlElement("post")]
        public Collection<PostDocModel> Post
        {
            get { return post; }
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
    [XmlRoot("post")]
    public class PostDocModel
    {
        private string _id;
        [XmlElement("id")]
        public string id
        {
            get { return _id; }
            set { _id = value; }
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
        private string _source;
        [XmlElement("source")]
        public string source
        {
            get { return _source; }
            set { _source = value; }
        }
        private string _reply_count;
        [XmlElement("reply_count")]
        public string reply_count
        {
            get { return _reply_count; }
            set { _reply_count = value; }
        }
        private PostDetailModel _deta;
        [XmlElement("detail")]
        public PostDetailModel deta
        {
            get { return _deta; }
            set { _deta = value; }
        }
        private PostGroupModel _group;
        [XmlElement("group")]
        public PostGroupModel group
        {
            get { return _group; }
            set { _group = value; }
        }
        private TaskDetailUsers _Puser;
        [XmlElement("user")]
        public TaskDetailUsers Puser
        {
            get { return _Puser; }
            set { _Puser = value; }
        }
    }
    [Serializable]
    [XmlRoot("group")]
    public class PostGroupModel
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
    [XmlRoot("detail")]
    public class PostDetailModel
    {
        private string _thumbnail_pic;
        [XmlElement("thumbnail_pic")]
        public string thumbnail_pic
        {
            get { return _thumbnail_pic; }
            set { _thumbnail_pic = value; }
        }
        private string _original_file;
        [XmlElement("original_file")]
        public string original_file
        {
            get { return _original_file; }
            set { _original_file = value; }
        }
        private string _original_filename;
        [XmlElement("original_filename")]
        public string original_filename
        {
            get { return _original_filename; }
            set { _original_filename = value; }
        }
        private string _filesize;
        [XmlElement("filesize")]
        public string filesize
        {
            get { return _filesize; }
            set { _filesize = value; }
        }
    }
}
