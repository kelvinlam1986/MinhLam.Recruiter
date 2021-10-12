namespace MinhLam.Recruiter.Infrastructure.Sessions
{
    public interface IUserCookie
    {
        bool RCRemember { get; set; }
        string RCRememberEmail { get; set; }
        string RCTime { get; set; }
    }
}
