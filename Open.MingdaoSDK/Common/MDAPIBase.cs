using System;
using System.Collections.Generic;
using System.Text;


namespace Open.MingdaoSDK.Common
{
    public class MDAPIBase : HttpRequestBase
    {
        public Parameter OauthKey;
        public MDAPIBase(Parameter oauthKey)
        {
            this.OauthKey = oauthKey;
        }

        public string SyncRequest(TypeOption option, List<Parameter> ListParam, List<Parameter> ListFile)
        {
            return base.SyncRequest(APIType.GetURL(option), APIType.GetHttpMethod(option), OauthKey, ListParam, ListFile);
        }

        public bool AsyncRequest(TypeOption option, List<Parameter> ListParam, List<Parameter> ListFile, AsyncRequestCallback Callback, out int CallbKey)
        {
            return base.AsyncRequest(APIType.GetURL(option), APIType.GetHttpMethod(option), OauthKey, ListParam, ListFile, Callback, out CallbKey);
        }

    }
}
