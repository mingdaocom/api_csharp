<%@ Page Language="C#" AutoEventWireup="true" CodeFile="access_token.aspx.cs" Inherits="access_token" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>获取授权过的令牌</title>
    <link href="css/Basic.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style=" margin-left:30px; margin-top:20px;border:1px solid #CCCCCC; width:800px; height:40px;">  
            <span>
                明道当前应用
            </span>
            <span style=" line-height:40px;">
                <asp:Button ID="GetAccessToken" runat="server" Text="获取访问令牌" Font-Names="微软雅黑" 
                onclick="authorize_Click" />
            </span>
            <span id="accesstoken" runat="server" style="color:Red;"></span>
        </div>
    </form>
</body>
</html>
