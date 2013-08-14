<%@ Page Language="C#" AutoEventWireup="true" CodeFile="authorize_default.aspx.cs" Inherits="authorize_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>请求用户授权</title>
    <link href="css/Basic.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style=" margin-left:30px; margin-top:20px;border:1px solid #CCCCCC; width:800px; height:40px;">  
            <span>
                明道当前应用
            </span>
            <span style=" line-height:40px;">
                <asp:Button ID="authorize" runat="server" Text="请求用户授权" Font-Names="微软雅黑" 
                onclick="authorize_Click" />
            </span>
        </div>
    </form>
</body>
</html>
