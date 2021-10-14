using MinhLam.Framework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhLam.Recruiter.Domain
{
    public class RCFolder : AggregateRoot
    {
        public Guid RecruiterId { get; set; }
        [ForeignKey("RecruiterId")]
        public RCAccount Recruiter { get; set; }
        public string FolderName { get; set; }
        public string  FolderDescription { get; set; }
        public string FolderManager { get; set; }

        public static RCFolder New(
            Guid recruiterId, 
            string folderName, 
            string folderDescription, 
            string folderManager,
            ICheckExisting checkExisting,
            IRCFolderRepository folderRepository)
        {
            bool hasFolderOfRecruiterWithName =
                checkExisting.FolderExistWithNameAndRecruiterId(recruiterId, folderName);

            var folderOfRecruiters = folderRepository.GetListFolderOfRecruiter(recruiterId);
            bool lessTenFolders = folderOfRecruiters.Count < 10;

            if (hasFolderOfRecruiterWithName == false && lessTenFolders)
            {
                return new RCFolder(
                   Guid.NewGuid(),
                   recruiterId,
                   folderName,
                   folderDescription,
                   folderManager);
            }

            return null;
        }

        protected RCFolder(
            Guid id, 
            Guid recruiterId, 
            string folderName, 
            string folderDescription, 
            string folderManager)
        {
            this.Id = id;
            this.RecruiterId = recruiterId;
            this.FolderName = folderName;
            this.FolderDescription = folderDescription;
            this.FolderManager = folderManager;
        }

        public RCFolder()
        {
        }
    }
}
