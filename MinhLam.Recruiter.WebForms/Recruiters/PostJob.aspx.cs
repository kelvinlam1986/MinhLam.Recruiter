using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Infrastructure.Sessions;
using Ninject;
using System;
using System.Web.UI.WebControls;

namespace MinhLam.Recruiter.WebForms.Recruiters
{
    public partial class PostJob : System.Web.UI.Page
    {
        [Inject]
        public IUserSession UserSession { get; set; }

        [Inject]
        public IRedirector Redirector { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.RCUserId == Guid.Empty)
            {
                Redirector.GoToLogin();
            }

            if (UserSession.RCActive == false)
            {
                btnSave.Enabled = false;
                btnActivate.Enabled = false;
                literalError.Text = "Bạn không thể sử dụng dịch vụ đăng tin ngay lúc này vì tài khoản bạn chưa được kích hoạt";
            }

            if (!IsPostBack)
            {
                LoadDataToDropDownList();
                string jobId = Request.QueryString["JobId"];
                postAndUpdateDate.Visible = false;
                if (string.IsNullOrEmpty(jobId) == false)
                {
                    literalID.Text = jobId;
                    if (LoadJob(jobId) == false)
                    {
                        btnActivate.Visible = false;
                        btnPreView.Visible = false;
                        literalError.Text = "Tin không hợp lệ";
                    }
                    else
                    {
                        postAndUpdateDate.Visible = true;
                        lblTitle.Text = "Cập nhật tin tuyển dụng";
                        btnSave.Text = "Cập nhật tin";
                        btnActivate.Visible = true;
                        btnActivate.Visible = true;
                        literalError.Text = "";
                    }
                }
                else
                {
                    if (IsEnablePostJob())
                    {
                        LoadRangeOfDate(ddlCloseDate, 30, "");
                    }
                    else
                    {
                        Response.Redirect("PostJob.aspx");
                    }
                }
            }
        }

        private void LoadRangeOfDate(DropDownList ddl, int days, string selectedDate)
        {

        }

        private bool IsEnablePostJob()
        {
            throw new NotImplementedException();
        }

        private bool LoadJob(string jobId)
        {
            throw new NotImplementedException();
        }

        private void LoadDataToDropDownList()
        {
            throw new NotImplementedException();
        }
    }
}