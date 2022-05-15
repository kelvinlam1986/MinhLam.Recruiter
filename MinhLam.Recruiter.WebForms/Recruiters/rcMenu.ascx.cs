using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MinhLam.Recruiter.WebForms.Recruiters
{
    public partial class rcMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pageCall = this.NamingContainer.Page.Title;
            HyperLink hyperLink;
            Literal literal;
            switch (pageCall)
            {
                case "::Tài khoản của tôi":
                case "::Thông tin công ty":
                case "::Đổi mật khẩu":
                case "::Cập nhật thông tin đăng nhập":

                    hyperLink = new HyperLink();
                    hyperLink.Text = "Cập nhật tài khoản";
                    hyperLink.NavigateUrl = "Register.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Thông tin công ty";
                    hyperLink.NavigateUrl = "Profile.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Logo công ty";
                    hyperLink.NavigateUrl = "Logo.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Đổi mật khẩu";
                    hyperLink.NavigateUrl = "ChangePassword.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Đăng xuất";
                    hyperLink.NavigateUrl = "Logout.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    TdMyAccount.BgColor = "#099999";
                    TdHome.BgColor = "#000099";
                    break;

                case "::Job Responses":
                case "::Response Letters":
                case "::Contacted Resumes":
                case "::Resume Manager":
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Contacted Resumes";
                    hyperLink.NavigateUrl = "contactedresumes.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Job Response";
                    hyperLink.NavigateUrl = "jobresponses.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Response Letters";
                    hyperLink.NavigateUrl = "responseletters.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Saved Resumes";
                    hyperLink.NavigateUrl = "resumemanager.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Logout";
                    hyperLink.NavigateUrl = "logout.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                  
                    break;
                case "::Quản lý Tin tuyển dụng":
                case "::Đặt mua":
                case "::Quản lý đặt mua":
                case "::Đăng tin":
                case "::Resume Details":
                case "::Tin chi tiết":
                case "::Tin đã đóng":
                case "::Job Posting":
                case "::Thư mục":
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Đăng tin";
                    hyperLink.NavigateUrl = "PostJob.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Quản lý đặt mua";
                    hyperLink.NavigateUrl = "jobpurchases.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Tin đã đóng";
                    hyperLink.NavigateUrl = "JobExpired.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Thư mục";
                    hyperLink.NavigateUrl = "jobfolders.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    TdMyAccount.BgColor = "#000099";
                    TdHome.BgColor = "#000099";
                    TdJobManager.BgColor = "#099999";
                    if (Session.Contents["rcuserid"] != null)
                    {
                        literal = new Literal();
                        literal.Text = " | ";
                        this.panelMenu.Controls.Add(literal);
                        hyperLink = new HyperLink();
                        hyperLink.Text = "Đăng xuất";
                        hyperLink.NavigateUrl = "Logout.aspx";
                        this.panelMenu.Controls.Add(hyperLink);
                    }
                    break;
                case "::Đăng nhập":
                case "::Log out":
                case "::Job Tools":
                case "::Đăng ký mới":
                case "::Quên mật khẩu":
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Đăng nhập";
                    hyperLink.NavigateUrl = "Login.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Đăng ký";
                    hyperLink.NavigateUrl = "Register.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Quên mật khẩu";
                    hyperLink.NavigateUrl = "ForgotPassword.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Công cụ";
                    hyperLink.NavigateUrl = "jobtools.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    break;

                case "::Saved Resume Searchs":
                case "::Search for Resumes":
                case "::Search job by Alphabet":
                case "::Search job by Location":
                case "::Search job by Company":
                case "::Search job by Category":
                case "::Search job by Industry":
                case "::Search Result":

                    hyperLink = new HyperLink();
                    hyperLink.Text = "Search by Province";
                    hyperLink.NavigateUrl = "location.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Search by Category";
                    hyperLink.NavigateUrl = "category.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Search by Industry";
                    hyperLink.NavigateUrl = "industry.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Search by Experience";
                    hyperLink.NavigateUrl = "experience.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Search by Alphabet";
                    hyperLink.NavigateUrl = "alphabet.aspx";
                    this.panelMenu.Controls.Add(hyperLink);

                    if (Session.Contents["rcuserid"] != null)
                    {
                        literal = new Literal();
                        literal.Text = " | ";
                        this.panelMenu.Controls.Add(literal);
                        hyperLink = new HyperLink();
                        hyperLink.Text = "Đăng xuất";
                        hyperLink.NavigateUrl = "Logout.aspx";
                        this.panelMenu.Controls.Add(hyperLink);
                    }
                    break;
                default:
                    literal = new Literal();
                    literal.Text = "<marquee>Có rất nhiều công việc phù hợp với bạn tại đây. Hãy đến và tìm một công việc phù hợp với bạn.</marquee>";
                    this.panelMenu.Controls.Add(literal);
                    break;
            }
        }
    }
}