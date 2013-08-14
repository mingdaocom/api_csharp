using System;
using System.Collections.Generic;
using System.Text;
using Open.MingdaoSDK;
using Open.MingdaoSDK.Entity;
using Open.MingdaoSDK.Common;
using System.Collections.Specialized;

namespace Open.MingdaoSDK
{
    public class Version
    {
        string _app_key = null;
        string _app_secret = null;
         /// <summary>
         /// 构造函数
         /// </summary>
        /// <param name="app_key">app_key</param>
        /// <param name="app_secret">app_secret</param>
        public Version(string app_key, string app_secret)
        {
            this._app_key = app_key;
            this._app_secret = app_secret;
        }
        /// <summary>
        /// 获取当前应用的最新版本
        /// </summary>
        /// <returns></returns>
        public VersionModel ShowVersion()
        {
            SyncHttp http = new SyncHttp();
            List<Parameter> Query = new List<Parameter>();
            Query.Add(new Parameter("app_key", _app_key));
            Query.Add(new Parameter("app_secret", _app_secret));
            string Url = APIType.GetURL(TypeOption.MD_version);
            string QueryStr = HttpUtility.NormalizeRequestParameters(Query);
            string Result = http.HttpGet(Url, QueryStr);
            if (!string.IsNullOrEmpty(Result))
            {
                return XmlSerializationHelper.XmlToObject<VersionModel>(Result);
            }
            return null;
        }

    }
}
