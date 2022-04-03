using System;

namespace MinhLam.Recruiter.Application.Commands
{
    public class RCFolderRemoveCommand
    {
        public RCFolderRemoveCommand(Guid folderId)
        {
            FolderId = folderId;
        }

        public Guid FolderId { get; set; }
    }
}
