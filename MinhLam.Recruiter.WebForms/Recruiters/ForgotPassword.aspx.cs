using MinhLam.Framework;
using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Application.Commands;
using MinhLam.Recruiter.Infrastructure.Sessions;
using Ninject;
using System;

namespace MinhLam.Recruiter.WebForms.Recruiters
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        [Inject]
        public IUserSession UserSession { get; set; }

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
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                var forgotPasswordCommand = new RCForgotPasswordCommand(
                    txtEmail.Text, txtCompanyName.Text, txtEnglishName.Text, Convert.ToDateTime(txtDOE.Text));
                string oldPassword =  MembershipService.RCGetForgetPassword(forgotPasswordCommand);
                literalError.Text = "Mật khẩu đã được gửi đến địa chỉ email của bạn.";
                Redirector.GoToLogin();
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