using MinhLam.Recruiter.Domain;
using System;
using System.Linq;

namespace MinhLam.Recruiter.Infrastructure.Domains
{
    public class CheckExisting : ICheckExisting
    {
        private readonly JobContext context;

        public CheckExisting(JobContext context)
        {
            this.context = context;
        }

        public bool FolderExistWithNameAndRecruiterId(Guid recruiterId, string name)
        {
            throw new NotImplementedException();
        }

        public bool ProvinceExistsWithId(Guid id)
        {
            var province = this.context.Provinces.FirstOrDefault(x => x.Id == id);
            return province != null;
        }

        public bool RCAccountExistWithEmail(string email)
        {
            var account = this.context.RCAccounts.FirstOrDefault(x => x.Email == email);
            return account != null;
        }

        public bool RCAccountExistWithId(Guid id)
        {
            var account = this.context.RCAccounts.FirstOrDefault(x => x.Id == id);
            return account != null;
        }

        public bool RCFolderExistsWithId(Guid id)
        {
            var folder = this.context.RCFolders.FirstOrDefault(x => x.Id == id);
            return folder != null;
        }

        public bool RCSavedSearchExistWith(Guid recruiterId, string keyword, Guid certificateId, Guid categoryId, Guid industryId, Guid provinceId, Guid workingTypeId, Guid workingLevelId, int gender, int availability, int minAge, int maxAge)
        {
            throw new NotImplementedException();
        }
    }
}
