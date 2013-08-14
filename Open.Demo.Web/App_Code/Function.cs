using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Xml;
using System.Net.Mail;
using System.Text;
using System.Data.OleDb;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

/// <summary>
/// Function 的摘要说明
/// </summary>
public class Function
{
    public static string VirtualPath = System.Web.VirtualPathUtility.ToAbsolute("~/");
    public Function()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    #region 弹出式信息
    /// <summary>
    /// 弹出式信息
    /// </summary>
    public static void JSAlertString(string message, System.Web.HttpResponse response)
    {
        string strJS = "<script language=\"javascript\">alert('" + message + "');</script>";
        response.Write(strJS);
    }


    #endregion

    #region 弹出式信息并关闭该窗口
    /// <summary>
    /// 弹出式信息并关闭该窗口
    /// </summary>
    public static void JSAlertClosePage(string message, System.Web.HttpResponse response)
    {
        string strJS = "<script language=\"javascript\">alert('" + message + "');this.window.close();</script>";
        response.Write(strJS);
        response.End();
    }
    #endregion

    #region 弹出式信息并跳转至页面
    /// <summary>
    /// 弹出信息并跳转页面
    /// </summary>
    public static void JSAlertTurnPage(string message, string turnPage, System.Web.HttpResponse response)
    {
        string strJS = "<script language=\"javascript\">alert('" + message + "');window.location.href='" + turnPage + "';</script>";
        response.Write(strJS);
        response.End();
    }
    #endregion
}
