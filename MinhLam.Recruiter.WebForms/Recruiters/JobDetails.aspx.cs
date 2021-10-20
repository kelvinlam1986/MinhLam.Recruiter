using MinhLam.Framework;
using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Application.Query;
using MinhLam.Recruiter.Infrastructure.Sessions;
using Ninject;
using System;

namespace MinhLam.Recruiter.WebForms.Recruiters
{
    public partial class JobDetails : System.Web.UI.Page
    {
        [Inject]
        public IUserSession UserSession { get; set; }

        [Inject]
        public IRedirector Redirector { get; set; }

        [Inject]
        public IWebContext WebContext { get; set; }

        [Inject]
        public IJobPostingQuery JobPostingQuery { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.RCUserId == Guid.Empty)
            {
                Redirector.GoToLogin();
            }

            if (!IsPostBack)
            {
                RegisterJavaScript();
                Guid jobId = WebContext.JobId;
                if (jobId != Guid.Empty)
                {
                    if (ShowDetail(jobId))
                    {
                        AdjustData();
                    }
                    else
                    {
                        hyperLinkPrint.Visible = false;
                        litError.Text = "Xin lỗi tin này không tồn tại";
                    }
                }
                else
                {
                    litError.Text = "Xin lỗi, tin này không tồn tại.";
                }
            }
        }

        private bool ShowDetail(Guid jobId)
        {
            var jobDetailList = JobPostingQuery.GetJobDetailByRecruiter(jobId, UserSession.RCUserId);
            if (jobDetailList != null && jobDetailList.Count > 0)
            {
                var jobDetail = jobDetailList[0];
                literalIntro.Text = jobDetail.AdvName;
                DetailsView1.DataSource = jobDetailList;
                DetailsView1.DataBind();
                return true;
            }

            return false;
        }

        private void AdjustData()
        {
            if (DetailsView1.Rows[16].Cells[0].Text != "")
                DetailsView1.Rows[16].Cells[0].Text
                = DetailsView1.Rows[16].Cells[
                0].Text.Replace("-", "<br>-");
            if (DetailsView1.Rows[18].Cells[0].Text != "")
                DetailsView1.Rows[18].Cells[0].Text =
                DetailsView1.Rows[18].Cells[
                0].Text.Replace("-", "<br>-");
        }

        private void RegisterJavaScript()
        {
            this.ClientScript.RegisterClientScriptBlock(
            this.GetType(), "openWindow" +
            this.DetailsView1.ID,
            Printer.CreateScriptForPrint(this.DetailsView1.ID));
            this.hyperLinkPrint.Attributes.Add("onclick", "openWindow" + this.DetailsView1.ID + "('" + DetailsView1.ID.ToString() + "', 500, 500);return false;");
        }
    }
}