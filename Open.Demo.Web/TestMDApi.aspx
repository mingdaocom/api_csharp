<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestMDApi.aspx.cs" Inherits="TestMDApi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>明道相关接口测试</title>
    <script type="text/javascript">
        //页面加载
        window.onload = function () {
            document.getElementById("InterfaceType").value = "1";
            document.getElementById("InterfaceType").onchange = function () {
                textchange();
                document.getElementById("ResultInfo").innerHTML = '';
            }
        }
        //为下拉框InterfaceType 做文本选定改变函数
        function textchange() {
            var select_value = document.getElementById("InterfaceType").value;
            divdisplay(select_value);
        }
        //只展现要展示的DIV 其他DIV全部隐藏
        function divdisplay(value) {
        if (value == 8 || value == 9)
        {
            value = 1;
        }
        else if (value == 10) {
            value = 8;
        }
            var index = parseInt(value) - 1;
            var str = ["get_feed_parameter", "post_feed_parameter", "get_post_replyment_parameter", "post_msg_parameter", "post_img_parameter", "get_userinfo_parameter", "creat_task_parameter", "replyment_feed_parameter"];
            for (var i = 0; i < str.length; i++) {
                if (index == i) {
                    DivIsShow(str[i], true);
                }
                else {
                    DivIsShow(str[i],false);
                }
            }
        }
        //为DIV的展现或隐藏 做公用函数
        function DivIsShow(id,isshow) {
            if (isshow) {
                document.getElementById(id).style.display = "block";
            }
            else {
                document.getElementById(id).style.display = "none";
            }
        }

        //验证必须参数是否为空
        function ParameterIsEmpty() {
             document.getElementById("ResultInfo").innerHTML='';
             var select_value = document.getElementById("InterfaceType").value;
             return CheckParameter(select_value);
        }

        //参数是否为空
        function CheckParameter(value) {
            if (value == 1 || value == 8 || value == 9) {
                if (!IsEmpty("u_key")) {
                    return false;
                }
                return true;
            }
            else if (value == 4) {
                if (!IsEmpty("post_msg_u_key")) {
                    return false;
                }
                if (!IsEmpty("post_msg_p_msg")) {
                    return false;
                }
                return true;
            }
            else if (value == 5) {
                if (!IsEmpty("post_img_u_key")) {
                    return false;
                }
                if (!IsEmpty("post_img_p_msg")) {
                    return false;
                }
                if (!IsEmpty("post_img_p_img")) {
                    return false;
                }
                return true;
            }
            else if (value == 3) {
                if (!IsEmpty("get_post_replyment_u_key")) {
                    return false;
                }
                if (!IsEmpty("get_post_replyment_p_id")) {
                    return false;
                }
                return true;
            }
            else if (value == 2) {
                if (!IsEmpty("post_feed_u_key")) {
                    return false;
                }
                if (!IsEmpty("post_feed_p_msg")) {
                    return false;
                }
                if (!IsEmpty("post_feed_re_p_id")) {
                    return false;
                }
                return true;
            }
            else if (value == 7) {
                if (!IsEmpty("creat_task_u_key")) {
                    return false;
                }
                if (!IsEmpty("creat_task_u_id")) {
                    return false;
                }
                if (!IsEmpty("creat_task_t_title")) {
                    return false;
                }
                if (!IsEmpty("creat_task_t_ed")) {
                    return false;
                }
                return true;
            }
            else if (value == 6) {
                if (!IsEmpty("get_userinfo_u_key")) {
                    return false;
                }
                if (!IsEmpty("get_userinfo_u_id")) {
                    return false;
                }
                return true;
            }
            else if (value == 10) {

                if (!IsEmpty("replyment_feed_u_key")) {
                    return false;
                }
                if (!IsEmpty("replyment_feed_p_id")) {
                    return false;
                }
                if (!IsEmpty("replyment_feed_r_msg")) {
                    return false;
                }
                return true;
            }
            return true;
        }
        //是否为空
        function IsEmpty(ID) {
            var value = document.getElementById(ID).value;
            if (value == "" || value == null) {
                alert("缺少必要参数！！！");
                return false;
            }
            return true;
        }
    </script>
    <link href="css/Basic.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <div style=" margin-left:auto; margin-right:auto; margin-top:30px;width:800px;">
            <fieldset style=" width:900px; height:460px;">
                <legend>明道应用接口测试</legend>
                <div style=" width:450px; float:left; margin-left:10px; height:440px;margin-top:20px;">
                    <div style=" font-size:18px; ">
                            API类型：
                    </div>
                    <div>
                        <select id="InterfaceType"  style=" width:200px;" runat="server">
                            <option value="1">读取用户及其所关注用户的动态更新</option>
                            <option value="2">转发一个feed</option>
                            <option value="10">回复一个feed</option>
                            <option value="3">读取一个feed的回复</option>
                            <option value="4">post一条动态信息</option>
                            <option value="5">post图片</option>
                            <option value="6">获取个人详细信息</option>
                            <option value="8">获取未读动态更新数量</option>
                            <option value="9">读取用户参与的任务列表</option>
                            <option value="7">创建一个任务</option>
                        </select>
                    </div>

                    <div style=" margin-top:10px;">
                        <span>参数列表：</span><br />
                        <div  style="width:360px; height:280px;border:1px solid #CCCCCC;">
                            <div id="get_feed_parameter" style="display:block;">
                                  <table>
                                        <tr>
                                            <td style="width:55px;"></td>
                                            <td style="width:50px;" >必须</td>
                                            <td style="width:70px;">类型及范围</td>
                                            <td style="width:185px;">说明</td>
                                        </tr>
                                        <tr>
                                            <td >u_key</td>
                                            <td >true</td>
                                            <td >string</td>
                                            <td >当前登录用户访问令牌</td>
                                        </tr>
                                        <tr>
                                            <td  >u_key:</td>
                                            <td colspan="3" align=left;>
                                                <input type="text" id="u_key" runat="server"/>
                                            </td>
                                        </tr>
                                       
                                  </table>
                            </div>

                            <div id="post_msg_parameter" style="display:none;">
                                  <table>
                                        <tr>
                                            <td style="width:55px;"></td>
                                            <td style="width:50px;" >必须</td>
                                            <td style="width:70px;">类型及范围</td>
                                            <td style="width:185px;">说明</td>
                                        </tr>
                                        <tr>
                                            <td >u_key</td>
                                            <td  >true</td>
                                            <td >string</td>
                                            <td >当前登录用户访问令牌</td>
                                        </tr>
                                         <tr>
                                            <td >p_msg</td>
                                            <td  >true</td>
                                            <td >string</td>
                                            <td >动态更新内容</td>
                                        </tr>
                                        <tr>
                                            <td  >u_key:</td>
                                            <td colspan="3" align="left"; >
                                                <input type="text" id="post_msg_u_key" runat="server"/>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td  >p_msg:</td>
                                            <td colspan="3" align="left"; >
                                                <input type="text" id="post_msg_p_msg" runat="server"/>
                                            </td>
                                        </tr>
                                       
                                  </table>
                            </div>

                            <div id="post_img_parameter" style=" display:none;">
                                    <table>
                                        <tr>
                                            <td style="width:55px;"></td>
                                            <td style="width:50px;" >必须</td>
                                            <td style="width:70px;">类型及范围</td>
                                            <td style="width:185px;">说明</td>
                                        </tr>
                                        <tr>
                                            <td >u_key</td>
                                            <td  >true</td>
                                            <td >string</td>
                                            <td >当前登录用户访问令牌</td>
                                        </tr>
                                            <tr>
                                            <td >p_msg</td>
                                            <td  >true</td>
                                            <td >string</td>
                                            <td >动态更新内容</td>
                                        </tr>
                                            <tr>
                                            <td >p_img</td>
                                            <td  >true</td>
                                            <td >binary</td>
                                            <td >要上传的图片。仅支持JPEG,GIF,PNG图片,目前上传图片大小限制为<5M。</td>
                                        </tr>
                                        <tr>
                                            <td  >u_key:</td>
                                            <td colspan="3" align="left"; >
                                                <input type="text" name="u_key" id="post_img_u_key" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  >p_msg:</td>
                                            <td colspan="3" align="left"; >
                                                <input type="text" name="p_msg" id="post_img_p_msg" runat="server" />
                                            </td>
                                        </tr>
                                            <tr>
                                            <td>p_img:</td>
                                            <td colspan="3" align="left"; >
                                                <input type="file" name="p_img" id="post_img_p_img" runat="server"/>
                                            </td>
                                        </tr>
                                      </table>
                            </div>

                             <div id="replyment_feed_parameter" style="display:none;">
                                  <table>
                                        <tr>
                                            <td style="width:55px;"></td>
                                            <td style="width:50px;" >必须</td>
                                            <td style="width:70px;">类型及范围</td>
                                            <td style="width:185px;">说明</td>
                                        </tr>
                                        <tr>
                                            <td >u_key</td>
                                            <td >true</td>
                                            <td >string</td>
                                            <td >当前登录用户访问令牌</td>
                                        </tr>
                                        <tr>
                                            <td >p_id</td>
                                            <td >true</td>
                                            <td >string</td>
                                            <td >动态更新编号</td>
                                        </tr>
                                        <tr>
                                            <td >r_msg</td>
                                            <td >true</td>
                                            <td >string</td>
                                            <td >回复的消息内容</td>
                                        </tr>
                                        <tr>
                                            <td  >u_key:</td>
                                            <td colspan="3" align=left; >
                                                <input type="text" id="replyment_feed_u_key" runat="server"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  >p_id:</td>
                                            <td colspan="3" align=left; >
                                                <input type="text" id="replyment_feed_p_id" runat="server"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  >r_msg:</td>
                                            <td colspan="3" align=left; >
                                                <input type="text" id="replyment_feed_r_msg" runat="server"/>
                                            </td>
                                        </tr>
                                  </table>
                            </div>

                            <div id="get_post_replyment_parameter" style="display:none;">
                                  <table>
                                        <tr>
                                            <td style="width:55px;"></td>
                                            <td style="width:50px;" >必须</td>
                                            <td style="width:70px;">类型及范围</td>
                                            <td style="width:185px;">说明</td>
                                        </tr>
                                        <tr>
                                            <td >u_key</td>
                                            <td >true</td>
                                            <td >string</td>
                                            <td >当前登录用户访问令牌</td>
                                        </tr>
                                        <tr>
                                            <td >p_id</td>
                                            <td >true</td>
                                            <td >string</td>
                                            <td >动态更新编号</td>
                                        </tr>
                                        <tr>
                                            <td  >u_key:</td>
                                            <td colspan="3" align=left; >
                                                <input type="text" id="get_post_replyment_u_key" runat="server"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  >p_id:</td>
                                            <td colspan="3" align=left; >
                                                <input type="text" id="get_post_replyment_p_id" runat="server"/>
                                            </td>
                                        </tr>
                                       
                                  </table>
                            </div>

                            <div id="post_feed_parameter" style="display:none;">
                                  <table>
                                        <tr>
                                            <td style="width:55px;"></td>
                                            <td style="width:50px;" >必须</td>
                                            <td style="width:70px;">类型及范围</td>
                                            <td style="width:185px;">说明</td>
                                        </tr>
                                        <tr>
                                            <td >u_key</td>
                                            <td >true</td>
                                            <td >string</td>
                                            <td >当前登录用户访问令牌</td>
                                        </tr>
                                        <tr>
                                            <td >p_msg</td>
                                            <td >true</td>
                                            <td >string</td>
                                            <td >动态更新内容</td>
                                        </tr>
                                        <tr>
                                            <td >re_p_id</td>
                                            <td >true</td>
                                            <td >string</td>
                                            <td >待转发的动态更新编号</td>
                                        </tr>
                                        <tr>
                                            <td  >u_key:</td>
                                            <td colspan="3" align=left; >
                                                <input type="text" id="post_feed_u_key" runat="server"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  >p_msg:</td>
                                            <td colspan="3" align=left; >
                                                <input type="text" id="post_feed_p_msg" runat="server"/>
                                            </td>
                                        </tr>
                                       <tr>
                                            <td  >re_p_id:</td>
                                            <td colspan="3" align=left; >
                                                <input type="text" id="post_feed_re_p_id" runat="server"/>
                                            </td>
                                        </tr>
                                  </table>
                            </div>

                            <div id="creat_task_parameter" style="display:none;">
                                  <table>
                                        <tr>
                                            <td style="width:55px;"></td>
                                            <td style="width:50px;" >必须</td>
                                            <td style="width:70px;">类型及范围</td>
                                            <td style="width:185px;">说明</td>
                                        </tr>
                                        <tr>
                                            <td >u_key</td>
                                            <td >true</td>
                                            <td >string</td>
                                            <td >当前登录用户访问令牌</td>
                                        </tr>
                                        <tr>
                                            <td >u_id</td>
                                            <td >true</td>
                                            <td >string</td>
                                            <td >指定的任务负责人</td>
                                        </tr>
                                        <tr>
                                            <td >t_title</td>
                                            <td >true</td>
                                            <td >string</td>
                                            <td >任务标题</td>
                                        </tr>
                                         <tr>
                                            <td >t_ed</td>
                                            <td >true</td>
                                            <td >string</td>
                                            <td >任务截止日期，yyyy-MM-dd形式</td>
                                        </tr>
                                        <tr>
                                            <td  >u_key:</td>
                                            <td colspan="3" align=left; >
                                                <input type="text" id="creat_task_u_key" runat="server"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  >u_id:</td>
                                            <td colspan="3" align=left; >
                                                <input type="text" id="creat_task_u_id" runat="server"/>
                                            </td>
                                        </tr>
                                       <tr>
                                            <td  >t_title:</td>
                                            <td colspan="3" align=left; >
                                                <input type="text" id="creat_task_t_title" runat="server"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  >t_ed:</td>
                                            <td colspan="3" align=left; >
                                                <input type="text" id="creat_task_t_ed" runat="server"/>
                                            </td>
                                        </tr>
                                  </table>
                            </div>

                            <div id="get_userinfo_parameter" style="display:none;">
                                  <table>
                                        <tr>
                                            <td style="width:55px;"></td>
                                            <td style="width:50px;" >必须</td>
                                            <td style="width:70px;">类型及范围</td>
                                            <td style="width:185px;">说明</td>
                                        </tr>
                                        <tr>
                                            <td >u_key</td>
                                            <td >true</td>
                                            <td >string</td>
                                            <td >当前登录用户访问令牌</td>
                                        </tr>
                                        <tr>
                                            <td >u_id</td>
                                            <td >true</td>
                                            <td >string</td>
                                            <td >要查询的用户编号</td>
                                        </tr>
                                        <tr>
                                            <td  >u_key:</td>
                                            <td colspan="3" align=left; >
                                                <input type="text" id="get_userinfo_u_key" runat="server"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  >u_id:</td>
                                            <td colspan="3" align=left; >
                                                <input type="text" id="get_userinfo_u_id" runat="server"/>
                                            </td>
                                        </tr>
                                  </table>
                            </div>
                        </div>
                        <div style=" margin:10px;">
                            <asp:Button ID="Test" OnClientClick="return ParameterIsEmpty();" runat="server" 
                                Text="测试" Font-Names="微软雅黑" Width=60  onclick="Test_Click"/>
                        </div>
                    </div>
                </div>


                <div  id="left" style=" width:410px; float:left;margin-left:20px; height:356px; margin-top:20px;">
                    <div style=" font-size:18px; ">
                        结果：
                   </div>
                    <div id="ResultInfo" runat="server" style="width:410px; height:332px;border:1px solid #CCCCCC; margin-top:0px; overflow:scroll;"></div>
                </div>
            </fieldset>
        </div>
    </form>
</body>
</html>
