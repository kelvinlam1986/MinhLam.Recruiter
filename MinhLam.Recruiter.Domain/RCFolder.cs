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
            if (string.IsNullOrEmpty(folderName))
            {
                throw new DomainException(DomainExceptionCode.FolderNameRequiredField,
                    "Bạn phải nhập tên thư mục");
            }

            if (checkExisting.RCAccountExistWithId(recruiterId) == false)
            {
                throw new DomainException(DomainExceptionCode.RCAccountCanNotFound,
                    "Không tìm thấy nhà tuyển dụng");
            }

            bool hasFolderOfRecruiterWithName =
                checkExisting.FolderExistWithNameAndRecruiterId(recruiterId, folderName);

            var folderOfRecruiters = folderRepository.GetListFolderOfRecruiter(recruiterId);
            bool lessTenFolders = folderOfRecruiters.Count < 10;

            if (hasFolderOfRecruiterWithName)
            {
                throw new DomainException(
                  DomainExceptionCode.RCFolderExists,
                  $"Thư mục {folderName} đã tồn tại");
            }

            if (hasFolderOfRecruiterWithName == false && lessTenFolders == false)
            {
                throw new DomainException(
                    DomainExceptionCode.OverMaximumFolderCreate,
                    "Bạn chỉ được tạo tối đa 10 thư mục");
            }

            return new RCFolder(
                   Guid.NewGuid(),
                   recruiterId,
                   folderName,
                   folderDescription,
                   folderManager);
        }

        public static RCFolder NewFromRemove(
            Guid folderId, 
            ICheckExisting checkExisting,
            IRCFolderRepository folderRepository)
        {
            var isExist = checkExisting.RCFolderExistsWithId(folderId);
            if (isExist == false)
            {
                throw new DomainException(DomainExceptionCode.CannotFoundRCFolder, "Không tìm thấy thư mục này");
            }

            var folder = folderRepository.GetById(folderId);
            return folder;
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
