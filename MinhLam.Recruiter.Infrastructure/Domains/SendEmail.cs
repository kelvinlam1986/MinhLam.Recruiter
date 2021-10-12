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
