using System;

namespace MinhLam.Recruiter.Application.Commands
{
    public class AddNewJobPostingCommand
    {
        public AddNewJobPostingCommand(
           Guid recruiterId,
           string jobTitle,
           string jobNo,
           int requiredNumber,
           string jobSummary,
           Guid workingTypeId,
           Guid experienceLevelId,
           int yearExperience,
           string rangeOfAge,
           string recruitmentType,
           int salaryFrom,
           int salaryTo,
           string currency,
           bool showSalary,
           bool salaryNegotive,
           DateTime closedDate,
           bool companyLogo,
           string advName,
           string jobSkill,
           Guid jobIndustryId,
           Guid jobCategoryId,
           Guid certificateId,
           string workLocation,
           Guid provinceId,
           Guid templateId,
           Guid folderId,
           bool enableApplyOnline,
           string onlyApplyUrl,
           string contactEmail,
           string contactPerson,
           string contactTel
           )
        {
            RecruiterId = recruiterId;
            JobTitle = jobTitle;
            JobNo = jobNo;
            RequiredNumber = requiredNumber;
            JobSummary = jobSummary;
            WorkingTypeId = workingTypeId;
            ExperienceLevelId = experienceLevelId;
            YearExperience = yearExperience;
            RangeOfAge = rangeOfAge;
            RecruitementType = recruitmentType;
            SalaryFrom = salaryFrom;
            SalaryTo = salaryTo;
            Currency = currency;
            ShowSalary = showSalary;
            SalaryNegotiate = salaryNegotive;
            ClosedDate = closedDate;
            CompanyLogo = companyLogo;
            AdvName = advName;
            JobSkill = jobSkill;
            JobIndustryId = jobIndustryId;
            JobCategoryId = jobCategoryId;
            CertificateId = certificateId;
            WorkLocation = workLocation;
            ProvinceId = provinceId;
            TemplateId = templateId;
            FolderId = folderId;
            EnableApplyOnline = enableApplyOnline;
            OnlyApplyUrl = onlyApplyUrl;
            ContactEmail = contactEmail;
            ContactPerson = contactPerson;
            ContactTel = contactTel;
        }

        public Guid RecruiterId { get; set; }
        public string JobTitle { get; set; }
        public string JobNo { get; set; }
        public int RequiredNumber { get; set; }
        public string JobSummary { get; set; }
        public Guid WorkingTypeId { get; set; }
        public Guid ExperienceLevelId { get; set; }
        public int YearExperience { get; set; }
        public string RangeOfAge { get; set; }
        public string RecruitementType { get; set; }
        public int SalaryFrom { get; set; }
        public int SalaryTo { get; set; }
        public string Currency { get; set; }
        public bool ShowSalary { get; set; }
        public bool SalaryNegotiate { get; set; }
        public DateTime ClosedDate { get; set; }
        public bool CompanyLogo { get; set; }
        public string AdvName { get; set; }
        public string JobSkill { get; set; }
        public Guid JobIndustryId { get; set; }
        public Guid JobCategoryId { get; set; }
        public Guid CertificateId { get; set; }
        public string WorkLocation { get; set; }
        public Guid ProvinceId { get; set; }
        public Guid TemplateId { get; set; }
        public Guid FolderId { get; set; }
        public bool EnableApplyOnline { get; set; }
        public string OnlyApplyUrl { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPerson { get; set; }
        public string ContactTel { get; set; }
    }
}
