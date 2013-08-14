using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Open.MingdaoSDK.Common
{
    public delegate void AsyncRequestCallback(int Key, string Content);

    class CallBackInfo
    {
        public int key = 0;
        public AsyncRequestCallback AsyncReqCCB = null;
    }
    public class HttpRequestBase
    {
        private Dictionary<AsyncHttp, CallBackInfo> AsyncRequestMap = new Dictionary<AsyncHttp, CallBackInfo>();
        private int key = 0;

        //同步请求
        public string SyncRequest(string Url, string HttpMethod, Parameter u_key, List<Parameter> ListParam, List<Parameter> ListFile)
        {
            if (ListParam == null)
                ListParam = new List<Parameter>();

            if (u_key != null)
                ListParam.Add(u_key);

            string QueryStr = HttpUtility.NormalizeRequestParameters(ListParam);

            SyncHttp Http = new SyncHttp();
            if (HttpMethod == "GET")
            {
                return Http.HttpGet(Url, QueryStr);
            }
            else if (ListFile == null || ListFile.Count == 0)
            {
                return Http.HttpPost(Url, QueryStr);

            }
            else
            {
                return Http.oAuthWebRequestWithPic(Url, QueryStr, ListFile[0].Value,Path.GetFileName(ListFile[0].Value));
            }

        }
        //异步请求
        public bool AsyncRequest(string Url, string HttpMethod, Parameter u_key, List<Parameter> ListParam, List<Parameter> ListFile, AsyncRequestCallback Callback, out int CallbackKey)
        {
            if (ListParam == null)
                ListParam = new List<Parameter>();

            if (u_key != null)
                ListParam.Add(u_key);
            string QueryString = HttpUtility.NormalizeRequestParameters(ListParam);


            AsyncHttp AHttp = new AsyncHttp();
            CallbackKey = GetKey();
            CallBackInfo CBInfo = new CallBackInfo();
            CBInfo.key = CallbackKey;
            CBInfo.AsyncReqCCB = Callback;

            AsyncRequestMap.Add(AHttp, CBInfo);

            bool BResult = false;
            if (HttpMethod.Equals("GET"))
            {
                BResult = AHttp.HttpGet(Url, QueryString, new AsyncHttpCallBack(HttpCallback));
            }
            else if (ListFile == null || ListFile.Count == 0)
            {
                BResult = AHttp.HttpPost(Url, QueryString, new AsyncHttpCallBack(HttpCallback));
            }
            else
            {
                BResult = AHttp.HttpPostFile(Url, QueryString, ListFile, new AsyncHttpCallBack(HttpCallback));
            }

            if (!BResult)
            {
                AsyncRequestMap.Remove(AHttp);
            }
            return BResult;
        }
        //回调函数
        protected void HttpCallback(AsyncHttp Http, string Content)
        {
            CallBackInfo info;
            if (!AsyncRequestMap.TryGetValue(Http, out info))
            {
                return;
            }
            if (info != null && info.AsyncReqCCB != null)
            {
                info.AsyncReqCCB(info.key, Content);
            }
            AsyncRequestMap.Remove(Http);
        }
        private int GetKey()
        {
            return ++key;
        }

    }
}
