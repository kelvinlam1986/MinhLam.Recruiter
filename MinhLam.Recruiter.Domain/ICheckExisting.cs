using System;

namespace MinhLam.Recruiter.Domain
{
    public interface ICheckExisting
    {
        bool RCAccountExistWithId(Guid id);
        bool RCAccountExistWithEmail(string email);
        bool ProvinceExistsWithId(Guid id);
        bool FolderExistWithNameAndRecruiterId(Guid recruiterId, string name);
        bool RCSavedSearchExistWith(
            Guid recruiterId,
            string keyword,
            Guid certificateId,
            Guid categoryId,
            Guid industryId,
            Guid provinceId,
            Guid workingTypeId,
            Guid workingLevelId,
            int gender,
            int availability,
            int minAge,
            int maxAge);
    }
}
