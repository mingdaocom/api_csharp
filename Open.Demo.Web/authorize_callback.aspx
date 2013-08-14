<%@ Page Language="C#" AutoEventWireup="true" CodeFile="authorize_callback.aspx.cs" Inherits="authorize_callback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>请求用户授权的回调页面</title>
    <link href="css/Basic.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style=" margin-left:30px; margin-top:20px;border:1px solid #CCCCCC; width:800px; height:40px;">  
            <span style="line-height:40px;">
                当前应用用户获取的明道请求验证码：
            </span>
            <span id="RequestCode" runat="server" style="line-height:40px;color:Red;">   
            </span>
        </div>
    </form>
</body>
</html>
