using MinhLam.Framework;
using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Application.Commands;
using MinhLam.Recruiter.Infrastructure.Sessions;
using Ninject;
using System;

namespace MinhLam.Recruiter.WebForms.Recruiters
{
    public partial class Login : System.Web.UI.Page
    {
        [Inject]
        public IUserSession UserSession { get; set; }

        [Inject]
        public IUserCookie UserCookie { get; set; }

        [Inject]
        public IRedirector Redirector { get; set; }

        [Inject]
        public IMembershipService MembershipService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.RCUserId != Guid.Empty)
            {
                Redirector.GoToRCMyAccount();
            }

            if (UserCookie.RCRemember == true)
            {
                txtEmail.Text = UserCookie.RCRememberEmail;
            }

            if (UserSession.RCLoginAttempts == 0)
            {
                UserSession.RCLoginAttempts = 1;
            }

            if (UserSession.RCLoginAttempts >= 3)
            {
                UserSession.RCLoginAttempts += 1;
                var randomWord = RandomHelper.RandomWord(9100 + UserSession.RCLoginAttempts);
                imageRestrict.ImageUrl = "~/RestrictLogin.ashx?word=" + randomWord;
                CompareValidator1.ValueToCompare = randomWord;
                Restrict.Visible = true;
            }
            else
            {
                Restrict.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserSession.RCLoginAttempts += 1;
            try
            {
                var loginCommand = new RCLoginCommand(txtEmail.Text, txtPassword.Text);
                this.MembershipService.RCLogin(loginCommand);
                var account = this.MembershipService.GetRCAccountByEmail(txtEmail.Text);
                if (account == null)
                {
                    literalError.Text = $"Tài khoản với email {txtEmail.Text} không tồn tại";
                    return;
                }

                this.UserSession.RCUserId = account.Id;
                this.UserSession.RCEmail = account.Email;
                this.UserSession.RCCompanyName = account.CompanyName;
                this.UserSession.RCJobFree = account.Agency;
                this.UserSession.RCActive = account.Activate;

                if (CheckBoxRememberEmail.Checked)
                {
                    this.UserCookie.RCRemember = true;
                    this.UserCookie.RCRememberEmail = account.Email;
                    this.UserCookie.RCTime = DateTime.Now.ToShortDateString();
                }

                this.UserSession.RCLoginAttempts = 0;
                this.Redirector.GoToRCMyAccount();
            }
            catch (DomainException ex)
            {
                this.literalError.Text = ex.Message;
                return;
            }
            catch (ApplicationServiceException ex)
            {
                this.literalError.Text = ex.Message;
                return;
            }
            catch (Exception)
            {
                this.literalError.Text = OperationExceptionCodes.InnerOperationProgramMessage;
                return;
            }
        }
    }
}