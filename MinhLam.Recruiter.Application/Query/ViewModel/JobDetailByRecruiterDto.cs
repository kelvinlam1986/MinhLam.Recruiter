using System;

namespace MinhLam.Recruiter.Application.Query.ViewModel
{
    public class JobDetailByRecruiterDto
    {
        public string AdvName { get; set; }
        public Guid RecruiterId { get; set; }
        public string CompanyName { get; set; }
        public Guid JobId { get; set; }
        public string JobNo { get; set; }
        public string JobTitle { get; set; }
        public string JobCategoryName { get; set; }
        public string JobIndustryName { get; set; }
        public string CertificateName { get; set; }
        public string WorkLocation { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPerson { get; set; }
        public string ContactTel { get; set; }
        public string JobSummary { get; set; }
        public string JobSkills { get; set; }
        public int SalaryFrom { get; set; }
        public int SalaryTo { get; set; }
        public string Currency { get; set; }
        public string SalaryNegotive { get; set; }
        public string ShowSalary { get; set; }
        public string CloseDate { get; set; }
        public string WorkingTypeName { get; set; }
        public string ExperienceLevelName { get; set; }
        public string RangeOfAge { get; set; }
        public string RecruitmentType { get; set; }
        public string YearExperience { get; set; }
        public int RequiredNumber { get; set; }
        public string OnlyApplyUrl { get; set; }
    }
}
