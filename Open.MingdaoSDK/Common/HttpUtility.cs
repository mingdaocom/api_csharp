using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using Microsoft.Win32;

namespace Open.MingdaoSDK.Common
{
    public static class HttpUtility
    {
        //根据文件名通过注册表获取文件类型
        public static string GetContentType(string FileName)
        {
            string ContentType = "application/octetstream";
            string ext = Path.GetExtension(FileName).ToLower();
            RegistryKey RegKey = Registry.ClassesRoot.OpenSubKey(ext);

            if (RegKey != null && RegKey.GetValue("Content Type") != null)
            {
                ContentType = RegKey.GetValue("Content Type").ToString();
            }

            return ContentType;
        }
        /// <summary>
        /// 根据参数格式化为key/value结构
        /// </summary>
        /// <param name="QueryStr"></param>
        /// <returns></returns>
        public static List<Parameter> GetQueryParameters(string Url)
        {
            List<Parameter> Results = new List<Parameter>();
            if (!string.IsNullOrEmpty(Url))
            {
                if (Url.StartsWith("?"))
                {
                    Url = Url.Remove(0, Url.IndexOf('?'));
                }
                else if (Url.StartsWith("&"))
                {
                    Url = Url.Remove(0, Url.IndexOf('&'));
                }
                else if (Url.StartsWith("#"))
                {
                    Url = Url.Remove(0, Url.IndexOf('#'));
                }
                string[] P = Url.Split('&');
                if (P == null) { return Results; }
                foreach (string tmp in P)
                {
                    if (!string.IsNullOrEmpty(tmp))
                    {
                        if (tmp.IndexOf('=') > -1)
                        {
                            string[] Dic = tmp.Split('=');
                            Results.Add(new Parameter(Dic[0], Dic[1]));
                        }
                    }
                }
                return Results;

            }
            return Results;
        }
        public static string NormalizeRequestParameters(List<Parameter> parameters)
        {
            StringBuilder sb = new StringBuilder();
            Parameter p = null;
            for (int i = 0; i < parameters.Count; i++)
            {
                p = parameters[i];
                sb.AppendFormat("{0}={1}", p.Name, p.Value);

                if (i < parameters.Count - 1)
                {
                    sb.Append("&");
                }
            }

            return sb.ToString();
        }
    }
}
