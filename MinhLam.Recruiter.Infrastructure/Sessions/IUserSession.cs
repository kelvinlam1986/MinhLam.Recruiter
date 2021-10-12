using System;

namespace MinhLam.Recruiter.Infrastructure.Sessions
{
    public interface IUserSession
    {
        Guid RCUserId { get; set; }
        string RCEmail { get; set; }
        string RCCompanyName { get; set; }
        bool RCJobFree { get; set; }
        bool RCActive { get; set; }
        int RCLoginAttempts { get; set; }
    }
}
