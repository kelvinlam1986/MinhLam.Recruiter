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
                case "::My Account":
                case "::Company Profile":
                case "::Change Password":
                case "::Update Login Information":

                    hyperLink = new HyperLink();
                    hyperLink.Text = "Update Account";
                    hyperLink.NavigateUrl = "register.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Company Profile";
                    hyperLink.NavigateUrl = "profile.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Company Logo";
                    hyperLink.NavigateUrl = "logo.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Change Password";
                    hyperLink.NavigateUrl = "changepassword.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Logout";
                    hyperLink.NavigateUrl = "logout.aspx";
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
                case "::Job Manager":
                case "::Job Purchase":
                case "::Post a Job":
                case "::Resume Details":
                case "::Job Details":
                case "::Job Expired":
                case "::Job Posting":
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Post a Job";
                    hyperLink.NavigateUrl = "postjob.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Job Purchasing";
                    hyperLink.NavigateUrl = "jobpurchases.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Closed Job";
                    hyperLink.NavigateUrl = "jobexpired.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Job Folders";
                    hyperLink.NavigateUrl = "jobfolders.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Logout";
                    hyperLink.NavigateUrl = "logout.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    break;
                case "::Login":
                case "::Log out":
                case "::Job Tools":
                case "::New Registration":
                case "::Forgot Password":
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Đăng nhập";
                    hyperLink.NavigateUrl = "login.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Đăng ký";
                    hyperLink.NavigateUrl = "register.aspx";
                    this.panelMenu.Controls.Add(hyperLink);
                    literal = new Literal();
                    literal.Text = " | ";
                    this.panelMenu.Controls.Add(literal);
                    hyperLink = new HyperLink();
                    hyperLink.Text = "Quên mật khẩu";
                    hyperLink.NavigateUrl = "forgotpassword.aspx";
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
                        hyperLink.Text = "Logout";
                        hyperLink.NavigateUrl = "logout.aspx";
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