using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Microsoft.Win32;
using System.Collections.Specialized;
using System.Web;
using System.Threading;

namespace Open.MingdaoSDK.Common
{
    public delegate void AsyncHttpCallBack(AsyncHttp Http, string Content);
    class RequestState
    {
        public const int BUFFER_SIZE = 1024;
        public byte[] BufferRead;
        public StringBuilder RequestData;
        public HttpWebRequest Request;
        public HttpWebResponse Response;
        public Stream StreamResponse;

        public AsyncHttpCallBack ACBack;

        //构造函数
        public RequestState()
        {
            BufferRead = new byte[BUFFER_SIZE];
            RequestData = new StringBuilder("");
            Request = null;
            StreamResponse = null;
            ACBack = null;
        }
    }
    //异步请求
    public class AsyncHttp
    {
        public ManualResetEvent WaitDone = new ManualResetEvent(false);
        const int DefaultTimeout = 60000;
        //异步发超GET请求
        public bool HttpGet(string Url, string Para, AsyncHttpCallBack ACB)
        {
            if (!string.IsNullOrEmpty(Para)) { Url = Url + "?" + Para; }

            HttpWebRequest Req = WebRequest.Create(Url) as HttpWebRequest;
            Req.Method = "Get";
            Req.ServicePoint.Expect100Continue = false;

            try
            {
                RequestState State = new RequestState();
                State.ACBack = ACB;
                State.Request = Req;
                IAsyncResult result = (IAsyncResult)Req.BeginGetResponse(new AsyncCallback(ResponseCallback), State);

                ThreadPool.RegisterWaitForSingleObject(result.AsyncWaitHandle, new WaitOrTimerCallback(TimeoutCallback), Req, DefaultTimeout, true);

                WaitDone.WaitOne();

                State.Response.Close();
            }
            catch (Exception ex)
            {
                return false;
            }


            return true;
        }
        //异步方式发起POST请求
        public bool HttpPost(string Url, string Para, AsyncHttpCallBack ACB)
        {
            StreamWriter Write = null;

            HttpWebRequest WebReq = WebRequest.Create(Url) as HttpWebRequest;
            WebReq.Method = "POST";
            WebReq.ContentType = "application/x-www-form-urlencoded";
            WebReq.ServicePoint.Expect100Continue = false;
            try
            {
                Write = new StreamWriter(WebReq.GetRequestStream());
                Write.Write(Para);
                Write.Close();
                Write = null;

                RequestState State = new RequestState();
                State.ACBack = ACB;
                State.Request = WebReq;

                IAsyncResult Result = (IAsyncResult)WebReq.BeginGetResponse(new AsyncCallback(ResponseCallback), State);
                ThreadPool.RegisterWaitForSingleObject(Result.AsyncWaitHandle, new WaitOrTimerCallback(TimeoutCallback), WebReq, DefaultTimeout, true);

                WaitDone.WaitOne();
                State.Response.Close();

            }
            catch (Exception ex)
            {
                if (Write != null)
                {
                    Write.Close();
                    Write = null;
                }
                return false;
            }
            finally
            {
                if (Write != null)
                {
                    Write.Close();
                    Write = null;
                }
            }
            return true;
        }

        public bool HttpPostFile(string Url, string Para, List<Parameter> Files, AsyncHttpCallBack AsyncCB)
        {
            Stream ReqStream = null;
            string Boundary = DateTime.Now.Ticks.ToString("x");

            Url = Url + "?" + Para;
            HttpWebRequest WebReq = WebRequest.Create(Url) as HttpWebRequest;
            WebReq.Method = "POST";
            WebReq.ServicePoint.Expect100Continue = true;
            WebReq.ContentType = "multipart/form-data; boundary=" + Boundary;
            WebReq.KeepAlive = true;
            WebReq.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                Stream MulStream = new MemoryStream();
                byte[] BoundaryByte = Encoding.ASCII.GetBytes("\r\n--" + Boundary + "\r\n");
                string FormdataTem = "\r\n--" + Boundary + "\r\nContent-Disposition:form-data:name=\"{0}\"\r\n\r\n{1}";
                List<Parameter> ListParm = HttpUtility.GetQueryParameters(Para);

                foreach (Parameter P in ListParm)
                {
                    string FormItem = string.Format(FormdataTem, P.Name, (FormParamDecode(P.Value)));
                    byte[] FormItemByte = Encoding.UTF8.GetBytes(FormItem);
                    MulStream.Write(FormItemByte, 0, FormItemByte.Length);
                }

                MulStream.Write(BoundaryByte, 0, BoundaryByte.Length);
                string HeaderTemp = "Content-Disposition:form-data:name=\"{0}\";filename=\"{1}\"\r\nContent-Type: \"{2}\"\r\n\r\n";

                foreach (Open.MingdaoSDK.Common.Parameter Pa in Files)
                {
                    string Name = Pa.Name;
                    string FilePath = Pa.Value;
                    string File = Path.GetFileName(FilePath);
                    string ContentType = HttpUtility.GetContentType(File);

                    string Header = string.Format(HeaderTemp, Name, File, ContentType);
                    byte[] HeaderBytes = Encoding.UTF8.GetBytes(Header);

                    MulStream.Write(HeaderBytes, 0, HeaderBytes.Length);

                    FileStream FileStr = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                    byte[] Buffer = new byte[1024];
                    int byteRead = 0;
                    while ((byteRead = FileStr.Read(Buffer, 0, Buffer.Length)) != 0)
                    {
                        MulStream.Write(Buffer, 0, byteRead);
                    }

                    MulStream.Write(BoundaryByte, 0, BoundaryByte.Length);

                    FileStr.Close();
                }

                WebReq.ContentLength = MulStream.Length;
                ReqStream = WebReq.GetRequestStream();

                MulStream.Position = 0;
                byte[] TmpBuffer = new byte[MulStream.Length];
                MulStream.Read(TmpBuffer, 0, TmpBuffer.Length);
                MulStream.Close();
                ReqStream.Write(TmpBuffer, 0, TmpBuffer.Length);
                ReqStream.Close();
                ReqStream = null;

                RequestState RState = new RequestState();
                RState.ACBack = AsyncCB;
                RState.Request = WebReq;

                IAsyncResult Result = (IAsyncResult)WebReq.BeginGetResponse(new AsyncCallback(ResponseCallback), RState);
                ThreadPool.RegisterWaitForSingleObject(Result.AsyncWaitHandle, new WaitOrTimerCallback(TimeoutCallback), WebReq, DefaultTimeout, true);
                WaitDone.WaitOne();

                RState.Response.Close();
            }
            catch (Exception ex)
            {
                if (ReqStream != null)
                {
                    ReqStream.Close();
                    ReqStream.Dispose();
                    ReqStream = null;
                }
                return false;
            }
            finally 
            {
                if (ReqStream != null)
                {
                    ReqStream.Close();
                    ReqStream.Dispose();
                    ReqStream = null;
                }
            }
            return true;
        }
        #region Private Methods
        private string FormParamDecode(string value)//转换%XX
        {
            int nCount = 0;
            for (int i = 0; i < value.Length; i++)//计算数组大小
            {
                if (value[i] == '%')
                {
                    i += 2;
                }
                nCount++;
            }

            byte[] sb = new byte[nCount];

            for (int i = 0, index = 0; i < value.Length; i++)
            {
                if (value[i] != '%')
                {
                    sb.SetValue((byte)value[i], index++);
                }
                else
                {
                    StringBuilder sChar = new StringBuilder();
                    sChar.Append(value[i + 1]);
                    sChar.Append(value[i + 2]);
                    sb.SetValue(Convert.ToByte(sChar.ToString(), 16), index++);
                    i += 2;
                }
            }
            UTF8Encoding utf8 = new UTF8Encoding();
            return utf8.GetString(sb);
        }


        private void ResponseCallback(IAsyncResult asynchronousResult)
        {
            // State of request is asynchronous.
            RequestState state = (RequestState)asynchronousResult.AsyncState;

            try
            {
                HttpWebRequest webRequest = state.Request;
                state.Response = (HttpWebResponse)webRequest.EndGetResponse(asynchronousResult);

                // Read the response into a Stream object.
                Stream responseStream = state.Response.GetResponseStream();
                state.StreamResponse = responseStream;

                IAsyncResult asynchronousInputRead = responseStream.BeginRead(state.BufferRead, 0,
                    RequestState.BUFFER_SIZE, new AsyncCallback(ReadCallBack), state);

                return;
            }
            catch
            {
                //fire back
                FireCallback(state);
            }

            WaitDone.Set();
        }
        //回调函数
        private void ReadCallBack(IAsyncResult asyncResult)
        {
            RequestState state = (RequestState)asyncResult.AsyncState;
            Stream responseStream = state.StreamResponse;

            try
            {
                int read = responseStream.EndRead(asyncResult);

                if (read > 0)
                {
                    state.RequestData.Append(Encoding.UTF8.GetString(state.BufferRead, 0, read));
                    IAsyncResult asynchronousResult = responseStream.BeginRead(state.BufferRead, 0,
                        RequestState.BUFFER_SIZE, new AsyncCallback(ReadCallBack), state);

                    return;
                }
                else
                {
                    //fire back
                    FireCallback(state);
                    responseStream.Close();
                }
            }
            catch
            {
                //fire back
                FireCallback(state);
                responseStream.Close();
            }

            WaitDone.Set();
        }

        // Abort the request if the timer fires.
        private void TimeoutCallback(object state, bool timedOut)
        {
            if (timedOut)
            {
                HttpWebRequest request = state as HttpWebRequest;
                if (request != null)
                {
                    request.Abort();
                }
            }
        }

        private void FireCallback(RequestState state)
        {
            //call back
            if (state.ACBack != null)
            {
                state.ACBack(this, state.RequestData.ToString());
            }
        }
        #endregion
    }

}
