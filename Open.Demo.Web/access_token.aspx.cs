using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Open.MingdaoSDK;
using Open.MingdaoSDK.Entity;
using Open.MingdaoSDK.Common;
using System.Configuration;

public partial class access_token : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void authorize_Click(object sender, EventArgs e)
    {
        //请求参数
        //分配到的App Key  必须参数
        string app_key = ConfigurationManager.AppSettings["app_key"];

        //分配到的app_secret  必须参数
        string app_secret = ConfigurationManager.AppSettings["app_secret"];

        //分配到的grant_type  必须参数  请求的类型，可以为authorization_code、password、refresh_token。
        string grant_type = "authorization_code";

        //分配到的code  必须参数 调用authorize获得的code值。
        string code = "";
        if (Session["code"] != null)
        {
            code = Session["code"].ToString();
        }

        //授权回调地址，站外应用需与设置的回调地址一致 必须参数
        string redirect_uri = ConfigurationManager.AppSettings["redirect_uri"];

        if (code == "")
        {
            Function.JSAlertString("没有请求验证码！", Response);
        }
        //此处我们以grant_type=authorization_code此种方式来获取访问令牌
        else
        {
            //1.初始化
            Authentication Oauth = new Authentication(app_key, app_secret, grant_type);
            //2.传参
            List<Open.MingdaoSDK.Common.Parameter> query = Oauth.GetParams(code, redirect_uri);
            //3.调用接口
            string U_key = Oauth.GetAccessTokenByAuthorized(query);
            //4.返回结果
            this.accesstoken.InnerHtml = "访问令牌为：" + U_key;
        }
    }
}