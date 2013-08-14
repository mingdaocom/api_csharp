using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using Microsoft.Win32;
using System.Collections.Specialized;
using System.Web;
using System.Globalization;

namespace Open.MingdaoSDK.Common
{
    public class SyncHttp
    {
        /// <summary>
        /// HTTP GET请求
        /// </summary>
        /// <param name="Url">URL</param>
        /// <param name="QueryStr">参数</param>
        /// <returns></returns>
        public string HttpGet(string Url, string QueryStr)
        {
            string ResponseData = null;
            if (!string.IsNullOrEmpty(QueryStr))
            {
                Url = Url + "?" + QueryStr;
            }
            HttpWebRequest WebReq = WebRequest.Create(Url) as HttpWebRequest;
            WebReq.Method = "GET";
            WebReq.ServicePoint.Expect100Continue = false;
            WebReq.Timeout = 20000;

            StreamReader Reader = null;
            try
            {
                Reader = new StreamReader(WebReq.GetResponse().GetResponseStream());
                ResponseData = Reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                WebReq.GetResponse().GetResponseStream().Close();
                Reader.Close();
                Reader = null;
                WebReq = null;
            }
            finally
            {

                WebReq.GetResponse().GetResponseStream().Close();
                Reader.Close();
                Reader = null;
                WebReq = null;
            }

            return ResponseData;
        }
        /// <summary>
        /// HTTP POST请求
        /// </summary>
        /// <param name="Url">URL</param>
        /// <param name="QueryString">参数</param>
        /// <returns></returns>
        public string HttpPost(string Url, string QueryString)
        {
            StreamReader Reader = null;
            Stream writer = null;
            byte[] PostData = null;

            if (!string.IsNullOrEmpty(QueryString))
            {
                PostData = Encoding.UTF8.GetBytes(QueryString);
            }
            string ResponseData = null;
            HttpWebRequest webRequest = WebRequest.Create(Url) as HttpWebRequest;
            webRequest.Method = "Post";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = PostData.Length;
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.Timeout = 20000;
            try
            {
                writer = webRequest.GetRequestStream();
                writer.Write(PostData, 0, PostData.Length);
                writer.Close();
                writer = null;

                Reader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                ResponseData = Reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                if (writer != null)
                {
                    writer.Close();
                    writer = null;
                }
                if (Reader != null)
                {
                    Reader.Close();
                    Reader = null;
                }
                webRequest.GetResponse().GetResponseStream().Close();
                webRequest = null;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer = null;
                }
                if (Reader != null)
                {
                    Reader.Close();
                    Reader = null;
                }
                webRequest.GetResponse().GetResponseStream().Close();
                webRequest = null;
            }
            return ResponseData;
        }
        /// <summary>
        /// HTTP POST请求，带附件提交
        /// </summary>
        /// <param name="Url">URL</param>
        /// <param name="QueryString">参数</param>
        /// <param name="Files">附件集合</param>
        /// <returns></returns>
        public string HttpPostFile(string Url, string QueryString, List<Parameter> Files)
        {
            Stream requestStream = null;
            StreamReader responseReader = null;
            Stream dataStream = null;
            string responseData = null;
            string boundary = DateTime.Now.Ticks.ToString("x");
            Url += '?' + QueryString;
            HttpWebRequest webRequest = WebRequest.Create(Url) as HttpWebRequest;
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.Timeout = 20000;
            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;
            webRequest.Method = "POST";
            webRequest.KeepAlive = true;
            webRequest.Credentials = CredentialCache.DefaultCredentials;

            try
            {
                Stream memStream = new MemoryStream();

                byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
                string formdataTemplate = "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";

                List<Parameter> listParams = HttpUtility.GetQueryParameters(QueryString);

                foreach (Parameter param in listParams)
                {
                    string formitem = string.Format(formdataTemplate, param.Name, param.Value);
                    byte[] formitembytes = Encoding.UTF8.GetBytes(formitem);
                    memStream.Write(formitembytes, 0, formitembytes.Length);
                }

                memStream.Write(boundarybytes, 0, boundarybytes.Length);

                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: \"{2}\"\r\n\r\n";

                foreach (Parameter param in Files)
                {
                    string name = param.Name;
                    string filePath = param.Value;
                    string file = Path.GetFileName(filePath);
                    string contentType = HttpUtility.GetContentType(file);

                    string header = string.Format(headerTemplate, name, file, contentType);
                    byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

                    memStream.Write(headerbytes, 0, headerbytes.Length);

                    FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;

                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        memStream.Write(buffer, 0, bytesRead);
                    }

                    memStream.Write(boundarybytes, 0, boundarybytes.Length);
                    fileStream.Close();
                }

                webRequest.ContentLength = memStream.Length;

                requestStream = webRequest.GetRequestStream();

                memStream.Position = 0;
                byte[] tempBuffer = new byte[memStream.Length];
                memStream.Read(tempBuffer, 0, tempBuffer.Length);
                memStream.Close();
                requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                requestStream.Close();
                requestStream = null;


                WebResponse response = webRequest.GetResponse();
                dataStream = response.GetResponseStream();
                responseReader = new StreamReader(dataStream);
                responseData = responseReader.ReadToEnd();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (requestStream != null)
                {
                    requestStream.Close();
                    requestStream = null;
                }

                if (responseReader != null)
                {
                    responseReader.Close();
                    responseReader = null;
                }
                if (dataStream != null)
                {
                    dataStream.Close();
                    dataStream = null;
                }
                if (responseData != null)
                {
                    responseData = null;
                }

                webRequest.GetResponse().GetResponseStream().Close();
                webRequest = null;
            }

            return responseData;
        }
        /// <summary>
        /// 更新动态信息，带图片的
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="filepath"></param>
        /// <param name="picName"></param>
        /// <returns></returns>
        public string oAuthWebRequestWithPic(string url, string postData, string filepath, string picName)
        {
            string UploadApiUrl = url;
            string msg = postData.Split('=').GetValue(1).ToString();

            if (postData.Length > 0)
            {
                NameValueCollection qs = System.Web.HttpUtility.ParseQueryString(postData);
                postData = "";
                msg = qs["p_msg"];
                foreach (string key in qs.AllKeys)
                {
                    if (postData.Length > 0)
                    {
                        postData += "&";
                    }
                    qs[key] = qs[key];
                    postData += (key + "=" + qs[key]);

                }
                if (url.IndexOf("?") > 0)
                {
                    url += "&";
                }
                else
                {
                    url += "?";
                }
                url += postData;
            }
            string boundary = Guid.NewGuid().ToString();
            HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create(url);

            string contentEncoding = "iso-8859-1";

            request.PreAuthenticate = true;
            request.AllowWriteStreamBuffering = true;
            request.Method = "POST";
            request.UserAgent = "Jakarta Commons-HttpClient/3.1";

            string header = string.Format("--{0}", boundary);
            string footer = string.Format("--{0}--", boundary);

            StringBuilder contents = new StringBuilder();
            request.ContentType = string.Format("multipart/form-data; boundary={0}", boundary);
            contents.AppendLine(header);
            contents.AppendLine(String.Format("Content-Disposition: form-data; name=\"{0}\"", "p_msg"));
            contents.AppendLine("Content-Type: text/plain; charset=US-ASCII");
            contents.AppendLine("Content-Transfer-Encoding: 8bit");
            contents.AppendLine();
            contents.AppendLine(msg);

            contents.AppendLine(header);
            string fileHeader = string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"", "p_img", picName);
            string fileData = System.Text.Encoding.GetEncoding(contentEncoding).GetString(File.ReadAllBytes(@filepath));

            contents.AppendLine(fileHeader);
            contents.AppendLine("Content-Type: application/octet-stream; charset=UTF-8");
            contents.AppendLine("Content-Transfer-Encoding: binary");
            contents.AppendLine();
            contents.AppendLine(fileData);
            contents.AppendLine(footer);

            byte[] bytes = Encoding.GetEncoding(contentEncoding).GetBytes(contents.ToString());
            request.ContentLength = bytes.Length;

            Stream requestStream = request.GetRequestStream();
            try
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }
            catch
            {
                throw;
            }
            finally
            {
                requestStream.Close();
                requestStream = null;
            }
            return getWebResponse(request);
        }
        /// <summary>
        /// 返回请求结果
        /// </summary>
        private string getWebResponse(HttpWebRequest webRequest)
        {
            StreamReader responseReader = null;
            string responseData = string.Empty;

            Stream dataStream = null;
            try
            {
                WebResponse response = webRequest.GetResponse();
                dataStream = response.GetResponseStream();
                responseReader = new StreamReader(dataStream);
                responseData = responseReader.ReadToEnd();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (dataStream != null)
                {
                    dataStream.Close();
                    dataStream = null;
                }
                if (responseReader != null)
                {
                    responseReader.Close();
                    responseReader = null;
                }
            }

            return responseData;
        }
    }
}
