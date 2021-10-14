using System;

namespace MinhLam.Recruiter.Infrastructure.Sessions
{
    public interface IWebContext
    {
        Guid RCUserId { get; set; }
        string RCEmail { get; set; }
        string RCCompanyName { get; set; }
        bool RCJobFree { get; set; }
        bool RCActive { get; set; }
        bool RCRemember { get; set; }
        string RCRememberEmail { get; set; }
        int RCLoginAttempts { get; set; }
        string RCTime { get; set; }
        Guid JobId { get; }
    }
}
