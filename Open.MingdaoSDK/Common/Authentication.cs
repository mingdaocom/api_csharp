using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Web;
using System.Security.Cryptography;
using Open.MingdaoSDK.Entity;

namespace Open.MingdaoSDK.Common
{
    public class Authentication
    {

        #region 单例模式
        ////这定义私有全局变量来保存唯一实例
        //private static Authentication Oauth;
        ////只读静对象
        //private static readonly object syncObject = new object();
        //private Authentication() { }//私有构造函数
        ////定义全局访问点，在类外部调用
        //public static Authentication GetInstance()
        //{
        //    //保证只实例化一次，即在第一次调用后就不会再实例化，杜绝多线程创建多个实例现象
        //    if (Oauth == null)
        //    {
        //        lock (syncObject)
        //        {
        //            if (Oauth == null)
        //            {
        //                Oauth = new Authentication();
        //            }
        //        }
        //    }
        //    return Oauth;
        //}
        #endregion
        SyncHttp http = new SyncHttp();
        string _app_key = null;
        string _app_secret = null;
        string _grant_type = null;

        #region 构造函数
        public Authentication(string app_key, string app_secret, string grant_type)
        {
            this._app_key = app_key;
            this._app_secret = app_secret;
            this._grant_type = grant_type;
        }
        #endregion
        /// <summary>
        /// 返回授权结果
        /// </summary>
        /// <param name="Queryparams">获取授权token参数</param>
        /// <returns></returns>
        public string GetAccessTokenByAuthorized(List<Parameter> Queryparams)
        {
            AuthModel Auths = null;
            string ResultStr = null;
            //ResultStr = http.HttpGet(APIType.GetURL(TypeOption.MD_OAUTH2_ACCESSTOKEN), HttpUtility.NormalizeRequestParameters(Queryparams));
            ResultStr = http.HttpGet(APIType.GetURL(TypeOption.MD_OAUTH2_ACCESSTOKEN), HttpUtility.NormalizeRequestParameters(Queryparams));
            Auths = XmlSerializationHelper.XmlToObject<AuthModel>(ResultStr);
            if (Auths != null)
            {
                if (!string.IsNullOrEmpty(Auths.Error_Code))
                {
                    return Auths.Error_Code;
                }
                return !string.IsNullOrEmpty(Auths.access_token) ? Auths.access_token : string.Empty;
            }
            else
                return "Error:10101";

        }
        /// <summary>
        /// 1）	grant_type为authorization_code时
        /// </summary>
        /// <param name="_code"></param>
        /// <param name="_redirect_uri"></param>
        /// <returns></returns>
        public List<Parameter> GetParams(string _code, string _redirect_uri)
        {
            List<Parameter> Param = new List<Parameter>();
            if (!string.IsNullOrEmpty(_app_key))
            {
                Param.Add(new Parameter("app_key", _app_key));
            }
            if (!string.IsNullOrEmpty(_app_secret))
            { Param.Add(new Parameter("app_secret", _app_secret)); }
            if (!string.IsNullOrEmpty(_grant_type))
            { Param.Add(new Parameter("grant_type", _grant_type)); }
            if (!string.IsNullOrEmpty(_code))
            {
                Param.Add(new Parameter("code", _code));
            }
            if (!string.IsNullOrEmpty(_redirect_uri))
            { Param.Add(new Parameter("redirect_uri", _redirect_uri)); }
            return Param;
        }
        /// <summary>
        /// 1）	grant_type为refresh_token时
        /// </summary>
        /// <param name="_refresh_token"></param>
        /// <returns></returns>
        public List<Parameter> GetParams(string _refresh_token)
        {
            List<Parameter> Param = new List<Parameter>();
            if (!string.IsNullOrEmpty(_app_key))
            {
                Param.Add(new Parameter("app_key", _app_key));
            }
            if (!string.IsNullOrEmpty(_app_secret))
            { Param.Add(new Parameter("app_secret", _app_secret)); }
            if (!string.IsNullOrEmpty(_grant_type))
            { Param.Add(new Parameter("grant_type", _grant_type)); }
            if (!string.IsNullOrEmpty(_refresh_token))
            { Param.Add(new Parameter("refresh_token", _refresh_token)); }
            return Param;
        }
        /// <summary>
        /// 1）	grant_type为password时
        /// </summary>
        /// <param name="_p_signature"></param>
        /// <param name="_username"></param>
        /// <param name="_password"></param>
        /// <returns></returns>
        public List<Parameter> GetParams(string _p_signature, string _username, string _password)
        {
            List<Parameter> Param = new List<Parameter>();
            if (!string.IsNullOrEmpty(_app_key))
            {
                Param.Add(new Parameter("app_key", _app_key));
            }
            if (!string.IsNullOrEmpty(_app_secret))
            { Param.Add(new Parameter("app_secret", _app_secret)); }
            if (!string.IsNullOrEmpty(_grant_type))
            { Param.Add(new Parameter("grant_type", _grant_type)); }
            if (!string.IsNullOrEmpty(_p_signature))
            {
                Param.Add(new Parameter("p_signature", _p_signature));
            }
            if (!string.IsNullOrEmpty(_username))
            { Param.Add(new Parameter("username", _username)); }
            if (!string.IsNullOrEmpty(_password))
            { Param.Add(new Parameter("password", _password)); }
            return Param;
        }
        private string GetRefreshToken(List<Parameter> Queryparam, string Name)
        {
            string RefreshToken = null;
            foreach (Open.MingdaoSDK.Common.Parameter tmp in Queryparam)
            {
                if (tmp.Name.Equals(Name))
                    RefreshToken = tmp.Value;
            }
            return RefreshToken;
        }
    }
}
