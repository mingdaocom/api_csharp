using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class authorize_callback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsCallback)
        {
            if (!string.IsNullOrEmpty(Request["code"]))
            {
                //获取重定向路径上的请求code
                this.RequestCode.InnerHtml = Request["code"];
                Session["code"] = Request["code"];
            }
        }
    }
}