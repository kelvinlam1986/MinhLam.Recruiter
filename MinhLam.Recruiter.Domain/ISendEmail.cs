namespace MinhLam.Recruiter.Domain
{
    public interface ISendEmail
    {
        void SendNewRegisterSuccessfulRCAccount(string emailAddress);
        void SendChangePasswordSuccessfulRCAccount(string emailAddress);
        void SendForgotPasswordRCAccount(string emailAddress, string oldPassword);
    }
}
