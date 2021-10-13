using System;

namespace MinhLam.Recruiter.Application.Commands
{
    public class RCChangePasswordCommand
    {
        public RCChangePasswordCommand(Guid recruiterId, string email, string oldPassword, string newPassword)
        {
            RecruiterId = recruiterId;
            Email = email;
            OldPassword = oldPassword;
            NewPassword = newPassword;
        }

        public Guid RecruiterId { get; set; }
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
