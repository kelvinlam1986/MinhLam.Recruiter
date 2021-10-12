using MinhLam.Framework;
using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Application.Commands;
using MinhLam.Recruiter.Application.Query;
using MinhLam.Recruiter.Infrastructure.Sessions;
using Ninject;
using System;

namespace MinhLam.Recruiter.WebForms.Recruiters
{
    public partial class MyAccount : System.Web.UI.Page
    {
        [Inject]
        public IUserSession UserSession { get; set; }

        [Inject]
        public IRedirector Redirector { get; set; }

        [Inject]
        public IViewRCAccountQuery ViewRCAccountQuery { get; set; }

        [Inject]
        public IMembershipService MembershipService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.RCUserId == Guid.Empty)
            {
                Redirector.GoToLogin();
            }

            lblAccount.Text = "Tài khoản " + UserSession.RCCompanyName;

            if (!IsPostBack)
            {
                ShowAccount();
            }
        }

        private void ShowAccount()
        {
            var result = ViewRCAccountQuery.GetMyRCAccount(UserSession.RCUserId);
            if (result != null)
            {
                hyperLinkTitle.Text = result.CompanyName;
                if (string.IsNullOrEmpty(result.EnglishName) == false)
                {
                    hyperLinkTitle.Text += "<br>(" + result.EnglishName + ")";
                }

                hyperLinkTitle.NavigateUrl = "Profile.aspx";

                if (result.AccountType == false)
                {
                    litAccountType.Text = "Công ty thuê người";
                }
                else
                {
                    litAccountType.Text = "Công ty săn việc";
                }

                litAgency.Text = result.Agency ? "Có" : "Không";

                if (result.Activate)
                {
                    litEnableForPosting.Text = "Có";
                    literalWarning.Text = "";
                }
                else
                {
                    litEnableForPosting.Text = "Chưa";
                    literalWarning.Text = "<img border='0' src='Icons/warning.gif'>" +
                        " Bạn không thể sử dụng RCV để đăng tin và xem tin, bởi vì tài khoản của bạn chưa được chấp thuận bới người quản lý";
                }

                litRegisterDate.Text = result.RegisterDate;
                litLastLogin.Text = result.LastLogin;
                litJobPostingBalance.Text = result.JobPostingBalance.ToString();
                litResumeViewingBalance.Text = result.ResumeViewingBalance.ToString();
                litAvailableForPosting.Text = result.AvailableForPosting.ToString();
                litAvailableForViewing.Text = result.AvailableForViewing.ToString();
                litHitViewed.Text = result.HitViewed.ToString();

                if (result.HitViewed == 0)
                {
                    lbtResetStatistics.Visible = false;
                }

                litJobNo.Text = result.JobNo.ToString();
            }
        }

        protected void lbtResetStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                var resetHitViewCmd = new RCResetHitViewCommand(UserSession.RCUserId);
                MembershipService.RCResetHitViewed(resetHitViewCmd);
                this.ShowAccount();
            }
            catch (DomainException ex)
            {
                literalError.Text = ex.Message;
            }
            catch (ApplicationServiceException ex)
            {
                literalError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                literalError.Text = ex.Message;
            }
           
        }
    }
}