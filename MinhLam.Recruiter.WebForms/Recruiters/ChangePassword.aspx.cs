using MinhLam.Framework;
using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Application.Commands;
using MinhLam.Recruiter.Infrastructure.Sessions;
using Ninject;
using System;

namespace MinhLam.Recruiter.WebForms.Recruiters
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        [Inject]
        public IUserSession UserSession { get; set; }

        [Inject]
        public IRedirector Redirector { get; set; }

        [Inject]
        public IMembershipService MembershipService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.RCUserId == Guid.Empty)
            {
                Redirector.GoToLogin();
            }

            if (UserSession.RCActive == false)
            {
                btnOK.Enabled = false;
                literalError.Text = "Bạn không thể thay đổi mật khẩu <br> bởi tài khoản của bạn chưa được chấp thuận";
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (UserSession.RCEmail == "")
            {
                Redirector.GoToLogin();
            }

            try
            {
                var changePasswordCommand = new RCChangePasswordCommand(
                    UserSession.RCUserId, UserSession.RCEmail, txtOldPassword.Text, txtPassword.Text);
                MembershipService.RCChangePassword(changePasswordCommand);
                literalError.Text = "Bạn đã thay đổi mật khẩu thành công. <br> Nó có hiệu lực ở lần đăng nhập tiếp theo";
                btnOK.PostBackUrl = "MyAccount.aspx";
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