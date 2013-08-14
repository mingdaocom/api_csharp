using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Open.MingdaoSDK;
using Open.MingdaoSDK.Entity;
using Open.MingdaoSDK.Common;

public partial class TestMDApi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //明道应有典型接口调用案例
    protected void Test_Click(object sender, EventArgs e)
    {
        switch (InterfaceType.Value)
        {
            //读取用户及其所关注用户的动态更新
            case "1":
                {
                    Open.MingdaoSDK.Common.Parameter U_key = new Open.MingdaoSDK.Common.Parameter("u_key", this.u_key.Value.Trim());
                    Post P = new Post(U_key);

                    PostResultModel Resut = P.Followed("", "", "", "");
                    ReturnPostResultlist(Resut);
                    break;
                }
            //转发一个feed
            case "2":
                {
                    Open.MingdaoSDK.Common.Parameter U_key = new Open.MingdaoSDK.Common.Parameter("u_key", this.post_feed_u_key.Value.Trim());
                    Post P = new Post(U_key);

                    string Resut = P.Repost("", this.post_feed_p_msg.Value.Trim(), this.post_feed_re_p_id.Value.Trim());
                    this.ResultInfo.InnerHtml = Resut;
                    break;
                }
            //回复一个feed
            case "10":
                {
                    Open.MingdaoSDK.Common.Parameter U_key = new Open.MingdaoSDK.Common.Parameter("u_key", this.replyment_feed_u_key.Value.Trim());
                    Post P = new Post(U_key);

                    string Resut = P.AddReply(this.replyment_feed_p_id.Value.Trim(), "", this.replyment_feed_r_msg.Value.Trim());
                    this.ResultInfo.InnerHtml = Resut;
                    break;
                }
            //读取一个的feed的回复
            case "3":
                {
                    Open.MingdaoSDK.Common.Parameter U_key = new Open.MingdaoSDK.Common.Parameter("u_key", this.get_post_replyment_u_key.Value.Trim());
                    Post P = new Post(U_key);

                    PostReplymentResultModel Resut = P.GetPostReplyByID(this.get_post_replyment_p_id.Value.Trim());
                    ReturnPostReplymentResultlist(Resut);
                    break;
                }
            // post动态信息
            case "4":
                {
                    Open.MingdaoSDK.Common.Parameter U_key = new Open.MingdaoSDK.Common.Parameter("u_key", this.post_msg_u_key.Value.Trim());
                    Post P = new Post(U_key);

                    string Resut = P.Update("", this.post_msg_p_msg.Value.Trim(), "");
                    this.ResultInfo.InnerHtml = Resut;
                    break;
                }
            //post图片
            case "5":
                {
                    string Fullfilename = post_img_p_img.PostedFile.FileName;
                    string ex = System.IO.Path.GetExtension(Fullfilename);
                    Random r = new Random();
                    string filename = DateTime.Now.Ticks + r.Next().ToString();
                    try
                    {
                        string FullFileURL = Server.MapPath("upload/ " + filename + ex);
                        post_img_p_img.PostedFile.SaveAs(FullFileURL);

                        Open.MingdaoSDK.Common.Parameter U_key = new Open.MingdaoSDK.Common.Parameter("u_key", this.post_img_u_key.Value.Trim());
                        Open.MingdaoSDK.Post P = new Open.MingdaoSDK.Post(U_key);

                        string Resut = P.Upload("", post_img_p_msg.Value.Trim(), FullFileURL, "", "");
                        this.ResultInfo.InnerHtml = Resut;
                    }
                    catch (Exception meg)
                    {
                        throw new Exception(meg.Message);
                    }
                    break;
                }
            //获取个人详细信息
            case "6":
                {
                    Open.MingdaoSDK.Common.Parameter U_key = new Open.MingdaoSDK.Common.Parameter("u_key", this.get_userinfo_u_key.Value.Trim());
                    User P = new User(U_key);

                    UserInfoModel Resut = P.GetUserDetail(this.get_userinfo_u_id.Value.Trim());
                    ReturnUserResultlist(Resut);
                    break;
                }
            //创建一个任务
            case "7":
                {
                    Open.MingdaoSDK.Common.Parameter U_key = new Open.MingdaoSDK.Common.Parameter("u_key", this.creat_task_u_key.Value.Trim());
                    Task P = new Task(U_key);

                    string Resut = P.Create(this.creat_task_t_title.Value.Trim(), "", this.creat_task_t_ed.Value.Trim(), this.creat_task_u_id.Value.Trim(), "");
                    this.ResultInfo.InnerHtml = Resut;
                    break;
                }
            //获取未读动态更新数量
            case "8":
                {
                    Open.MingdaoSDK.Common.Parameter U_key = new Open.MingdaoSDK.Common.Parameter("u_key", this.u_key.Value.Trim());
                    Post P = new Post(U_key);

                    string Resut = P.GetUnreadCount();
                    this.ResultInfo.InnerHtml = Resut;
                    break;
                }
            //获取当前登录用户参与的任务列表
            case "9":
                {
                    Open.MingdaoSDK.Common.Parameter U_key = new Open.MingdaoSDK.Common.Parameter("u_key", this.u_key.Value.Trim());
                    Task P = new Task(U_key);

                    TaskResultModel Resut = P.GetMyJoined();
                    ReturnTaskResultlist(Resut);
                    break;
                }
        }
    }

    //获取动态更新信息列表
    public void ReturnPostResultlist(PostResultModel Resut)
    {
        if (Resut != null && string.IsNullOrEmpty(Resut.Error_Code) && Resut.Posts.Count > 0)
        {
            string html = "";
            html += "<table>";
            html += "<tr>";
            html += "<td style=\"width:60px;\">id";
            html += "</td>";
            html += "<td style=\"width:200px;\">text";
            html += "</td>";
            html += "<td style=\"width:60px;\">create_time";
            html += "</td>";
            html += "</tr>";
            foreach (PostModel tmp in Resut.Posts)
            {
                PostModel postinfo = tmp;

                html += "<tr>";
                html += "<td>";
                html += postinfo.id;
                html += "</td>";
                html += "<td>";
                html += postinfo.text;
                html += "</td>";
                html += "<td>";
                html += postinfo.create_time;
                html += "</td>";
                html += "</tr>";

            }
            html += "</table>";
            this.ResultInfo.InnerHtml = html;
        }
        if (Resut != null)
        {
            if (!string.IsNullOrEmpty(Resut.Error_Code))
            {
                this.ResultInfo.InnerHtml = Resut.Error_Code;
            }
            else if (Resut.Posts.Count == 0)
            {
                this.ResultInfo.InnerHtml = "此用户暂无动态更新.";
            }
        }
    }
    //获取动态返回信息列表
    public void ReturnPostReplymentResultlist(PostReplymentResultModel Resut)
    {
        if (Resut != null && string.IsNullOrEmpty(Resut.Error_Code) && Resut.PostReplyment.Count > 0)
        {
            string html = "";
            html += "<table>";
            html += "<tr>";
            html += "<td>create_time";
            html += "</td>";
            html += "<td>name";
            html += "</td>";
            html += "<td>text";
            html += "</td>";
            html += "</tr>";
            foreach (PostReplymentModel tmp in Resut.PostReplyment)
            {
                PostReplymentModel postinfo = tmp;

                html += "<tr>";
                html += "<td>";
                html += postinfo.create_time;
                html += "</td>";
                html += "<td>";
                html += postinfo.Ruser.name;
                html += "</td>";
                html += "<td>";
                html += postinfo.text;
                html += "</td>";
                html += "</tr>";

            }
            html += "</table>";
            this.ResultInfo.InnerHtml = html;
        }
        if (Resut != null)
        {
            if (!string.IsNullOrEmpty(Resut.Error_Code))
            {
                this.ResultInfo.InnerHtml = Resut.Error_Code;
            }
            else if (Resut.PostReplyment.Count == 0)
            {
                this.ResultInfo.InnerHtml = "当前用户此动态暂无回复.";
            }
        }
    }
    //返回用户基本信息
    public void ReturnUserResultlist(UserInfoModel Resut)
    {
        if (Resut != null && string.IsNullOrEmpty(Resut.Error_Code))
        {
            string html = "";
            html += "<table>";
            html += "<tr>";
            html += "<td>company";
            html += "</td>";
            html += "<td>email";
            html += "</td>";
            html += "<td>job";
            html += "</td>";
            html += "</tr>";
            html += "<tr>";
            html += "<td>";
            html += Resut.Userdetail.company;
            html += "</td>";
            html += "<td>";
            html += Resut.Userdetail.email;
            html += "</td>";
            html += "<td>";
            html += Resut.Userdetail.job;
            html += "</td>";
            html += "</tr>";
            html += "</table>";
            this.ResultInfo.InnerHtml = html;
        }

        if (Resut != null && !string.IsNullOrEmpty(Resut.Error_Code))
        {
            this.ResultInfo.InnerHtml = Resut.Error_Code;
        }
    }
    //返回任务结果列表
    public void ReturnTaskResultlist(TaskResultModel Resut)
    {
        if (Resut != null && string.IsNullOrEmpty(Resut.Error_Code) && Resut.Tasks.Count > 0)
        {
            string html = "";
            html += "<table>";
            html += "<tr>";
            html += "<td>title";
            html += "</td>";
            html += "<td>expire_date";
            html += "</td>";
            html += "<td>name";
            html += "</td>";
            html += "</tr>";
            foreach (TaskModel tmp in Resut.Tasks)
            {
                TaskModel postinfo = tmp;

                html += "<tr>";
                html += "<td>";
                html += postinfo.title;
                html += "</td>";
                html += "<td>";
                html += postinfo.expire_date;
                html += "</td>";
                html += "<td>";
                html += postinfo.RUser.name;
                html += "</td>";
                html += "</tr>";

            }
            html += "</table>";
            this.ResultInfo.InnerHtml = html;
        }


        if (Resut != null)
        {
            if (!string.IsNullOrEmpty(Resut.Error_Code))
            {
                this.ResultInfo.InnerHtml = Resut.Error_Code;
            }
            else if (Resut.Tasks.Count == 0)
            {
                this.ResultInfo.InnerHtml = "此用户暂无相关任务.";
            }
        }
    }

}