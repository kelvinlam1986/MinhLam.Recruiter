using System;
using System.Collections.Generic;

namespace MinhLam.Recruiter.Domain
{
    public interface IGetData
    {
        RCAccount GetRCAccountById(Guid id);
        RCAccount GetRCAccountByEmail(string email);
        List<Province> GetProvinces();
        List<JobCategory> GetJobCategories();
        List<JobIndustry> GetJobIndustries();
        List<JSCertificate> GetJSCertificates();
        List<ExperienceLevel> GetExperienceLevels();
        List<WorkingType> GetWorkingTypes();
        List<RCFolder> GetFoldersOfRecruiter(Guid recruiterId);
        List<Template> GetTemplates();
    }
}
