using System;

namespace MinhLam.Recruiter.Application.Commands
{
    public class RCResetHitViewCommand
    {
        public RCResetHitViewCommand(Guid recruiterId)
        {
            RecruiterId = recruiterId;
        }

        public Guid RecruiterId { get; set; }
    }
}
