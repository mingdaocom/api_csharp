using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;

public partial class authorize_default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void authorize_Click(object sender, EventArgs e)
    {
        //请求参数
                                                                                                        
        //分配到的app_key  必须参数
        string app_key = ConfigurationManager.AppSettings["app_key"];

        //授权回调地址，站外应用需与设置的回调地址一致 必须参数
        string redirect_uri = ConfigurationManager.AppSettings["redirect_uri"];
        //返回类型，支持code、token，默认值为code。
        string response_type = "";

        //用于保持请求和回调的状态，在回调时，会在Query Parameter中回传该参数。
        string state = "";

        //授权页面的终端类型  default:默认的授权页面，适用于web浏览器;popup:弹窗类型的授权页，适用于web浏览器小窗口。
        string display = "";

        //拼接请求授权路径
        string requestURL = "";
        requestURL += "https://api.mingdao.com/auth2/authorize?";
        requestURL += "app_key=" + app_key;
        requestURL += "&redirect_uri=" + redirect_uri;
        Response.Redirect(requestURL);
    }
}