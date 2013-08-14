using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Open.MingdaoSDK.Entity
{
    [Serializable]
    [XmlRoot("project")]
    public class TaskProjectModel
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
    [XmlRoot("result")]
    public class TaskProjectResultModel
    {
        private Collection<TaskProjectModel> taskPros = new Collection<TaskProjectModel>();
        [XmlElement("task")]
        public Collection<TaskProjectModel> TaskPros
        {
            get { return taskPros; }
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
