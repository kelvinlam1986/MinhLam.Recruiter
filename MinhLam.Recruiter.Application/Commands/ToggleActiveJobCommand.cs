using System;

namespace MinhLam.Recruiter.Application.Commands
{
    public class ToggleActiveJobCommand
    {
        public ToggleActiveJobCommand(Guid jobId)
        {
            JobId = jobId;
        }

        public Guid JobId { get; set; }
    }
}
