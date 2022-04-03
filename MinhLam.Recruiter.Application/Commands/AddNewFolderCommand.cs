using System;

namespace MinhLam.Recruiter.Application.Commands
{
    public class AddNewFolderCommand
    {
        public AddNewFolderCommand(
            Guid recruiterId,
            string folderName,
            string folderDecription,
            string folderManager)
        {
            RecruiterId = recruiterId;
            FolderName = folderName;
            FolderDescription = folderDecription;
            FolderManager = folderManager;
        }

        public Guid RecruiterId { get; set; }
        public string FolderName { get; set; }
        public string FolderDescription { get; set; }
        public string FolderManager { get; set; }
    }
}
