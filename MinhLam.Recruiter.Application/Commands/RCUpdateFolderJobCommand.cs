using System;

namespace MinhLam.Recruiter.Application.Commands
{
    public class RCUpdateFolderJobCommand
    {
        public RCUpdateFolderJobCommand(
            Guid jobId,
            Guid folderId)
        {
            JobId = jobId;
            FolderId = folderId;
        }

        public Guid JobId { get; set; }
        public Guid FolderId { get; set; }
    }
}
