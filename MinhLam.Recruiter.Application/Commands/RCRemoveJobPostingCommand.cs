using System;

namespace MinhLam.Recruiter.Application.Commands
{
    public class RCRemoveJobPostingCommand
    {
        public RCRemoveJobPostingCommand(Guid jobId)
        {
            JobId = jobId;
        }

        public Guid JobId { get; set; }
    }
}
