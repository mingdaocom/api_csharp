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
    [XmlRoot("result")]
    public class VersionModel
    {
        private string _AppVersion;
        [XmlElement("AppVersion")]
        public string AppVersion
        {
            get { return _AppVersion; }
            set { _AppVersion = value; }
        }
        private string _AppUrl;
        [XmlElement("AppUrl")]
        public string AppUrl
        {
            get { return _AppUrl; }
            set { _AppUrl = value; }
        }
        private string _AppReleaseTime;
        [XmlElement("AppReleaseTime")]
        public string AppReleaseTime
        {
            get { return _AppReleaseTime; }
            set { _AppReleaseTime = value; }
        }
    }
}
