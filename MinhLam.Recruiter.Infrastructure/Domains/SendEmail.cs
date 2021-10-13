using MinhLam.Framework;
using MinhLam.Recruiter.Domain;
using MinhLam.Recruiter.Infrastructure.Configuration;

namespace MinhLam.Recruiter.Infrastructure.Domains
{
    public class SendEmail : ISendEmail
    {
        private readonly IApplicationSettings settings;

        public SendEmail(IApplicationSettings settings)
        {
            this.settings = settings;
        }

        public void SendChangePasswordSuccessfulRCAccount(string emailAddress)
        {
            var siteEmail = this.settings.SiteEmail;
            string message = "Mật khẩu của bạn đã thay đổi thành công. <br> Cám ơn bạn đã sử dụng dịch vụ Timviecnhanh.com";
            EmailHelper.SendEmail(siteEmail, emailAddress, "", "", "Thay đổi mật khẩu", message);
        }

        public void SendForgotPasswordRCAccount(string emailAddress, string oldPassword)
        {
            var siteEmail = this.settings.SiteEmail;
            string message = $"Đây là mật khẩu của bạn {oldPassword}. <br> Cám ơn bạn đã sử dụng dịch vụ Timviecnhanh.com";
            EmailHelper.SendEmail(siteEmail, emailAddress, "", "", "Quên mật khẩu", message);
        }

        public void SendNewRegisterSuccessfulRCAccount(string emailAddress)
        {
            var siteEmail = this.settings.SiteEmail;
            string message = "Cám ơn bạn đã đăng ký tại Timviecnhanh.com." +
                    " Chúng tôi sẽ xem xét tài khoản của bạn " +
                    "và sẽ gửi lại email trả lời cho bạn sớm nhất.";
            EmailHelper.SendEmail(siteEmail, emailAddress, "", "", "Đăng ký tài khoản tại Timviecnhanh.com", message);
        }
    }
}
