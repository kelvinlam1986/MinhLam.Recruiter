using MinhLam.Recruiter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhLam.Recruiter.Infrastructure.Domains
{
    public class GetData : IGetData
    {
        private readonly JobContext context;

        public GetData(JobContext context)
        {
            this.context = context;
        }

        public List<ExperienceLevel> GetExperienceLevels()
        {
            return this.context.ExperienceLevels.ToList();
        }

        public List<RCFolder> GetFoldersOfRecruiter(Guid recruiterId)
        {
            return this.context.RCFolders.Where(x => x.RecruiterId == recruiterId).ToList();
        }

        public List<JobCategory> GetJobCategories()
        {
            return this.context.JobCategories.ToList();
        }

        public List<JobIndustry> GetJobIndustries()
        {
            return this.context.JobIndustries.ToList();
        }

        public List<JSCertificate> GetJSCertificates()
        {
            return this.context.JSCertificates.ToList();
        }

        public List<Province> GetProvinces()
        {
            return this.context.Provinces.ToList();
        }

        public RCAccount GetRCAccountByEmail(string email)
        {
            return this.context.RCAccounts.FirstOrDefault(x => x.Email == email);
        }

        public RCAccount GetRCAccountById(Guid id)
        {
            return this.context.RCAccounts.FirstOrDefault(x => x.Id == id);
        }

        public List<Template> GetTemplates()
        {
            return this.context.Templates.ToList();
        }

        public List<WorkingType> GetWorkingTypes()
        {
            return this.context.WorkingTypes.ToList();
        }
    }
}
