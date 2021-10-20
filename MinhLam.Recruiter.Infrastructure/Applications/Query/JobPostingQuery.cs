using MinhLam.Recruiter.Application.Query;
using MinhLam.Recruiter.Application.Query.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhLam.Recruiter.Infrastructure.Applications.Query
{
    public class JobPostingQuery : IJobPostingQuery
    {
        private readonly JobContext jobContext;

        public JobPostingQuery(JobContext context)
        {
            this.jobContext = context;
        }

        public List<JobDetailByRecruiterDto> GetJobDetailByRecruiter(Guid jobId, Guid recruiterId)
        {
            var jobPosting = jobContext.RCJobPostings
                            .Include("Recruiter")
                            .Include("JobCategory")
                            .Include("JobIndustry")
                            .Include("Certificate")
                            .Include("WorkingType")
                            .Include("ExperienceLevel")
                            .FirstOrDefault(x => x.Id == jobId && x.RecruiterId == recruiterId);
            if (jobPosting == null)
            {
                return null;
            }

            var result = new JobDetailByRecruiterDto();
            result.JobId = jobPosting.Id;
            result.AdvName = jobPosting.AdvName;
            result.RecruiterId = jobPosting.RecruiterId;
            result.CompanyName = jobPosting.Recruiter?.CompanyName;
            result.JobNo = jobPosting.JobNo;
            result.JobTitle = jobPosting.JobTitle;
            result.JobCategoryName = jobPosting.JobCategory?.Name;
            result.JobIndustryName = jobPosting.JobIndustry?.Name;
            result.CertificateName = jobPosting.Certificate?.Name;
            result.WorkLocation = jobPosting.WorkLocation;
            result.ContactEmail = jobPosting.ContactEmail;
            result.ContactPerson = jobPosting.ContactPerson;
            result.ContactTel = jobPosting.ContactTel;
            result.JobSummary = jobPosting.JobSummary;
            result.JobSkills = jobPosting.JobSkill;
            result.SalaryFrom = jobPosting.SalaryFrom;
            result.SalaryTo = jobPosting.SalaryTo;
            result.Currency = jobPosting.Currency;
            result.SalaryNegotive = jobPosting.SalaryNegotive ? "Có" : "Không";
            result.ShowSalary = jobPosting.ShowSalary ? "Có" : "Không";
            result.CloseDate = jobPosting.ClosedDate.ToString("dd/MM/yyyy");
            result.WorkingTypeName = jobPosting.WorkingType?.Name;
            result.ExperienceLevelName = jobPosting.ExperienceLevel?.Name;
            result.RangeOfAge = jobPosting.RangeOfAge;
            result.RecruitmentType = jobPosting.RecruitmentType;
            result.RequiredNumber = jobPosting.RequiredNumber;
            result.YearExperience = $"Ít nhất {jobPosting.YearExperience} năm";
            result.OnlyApplyUrl = jobPosting.OnlyApplyUrl;

            var listResult = new List<JobDetailByRecruiterDto>();
            listResult.Add(result);
            return listResult;
        }

        public List<JobPostingDto> GetJobList(
            Guid recruiterId,
            bool isActive,
            Guid folderId,
            int page,
            int pageSize,
            out int totalRow,
            string sortColumn = "",
            string sortType = "")
        {
            var query = jobContext.RCJobPostings
                            .Include("JobCategory")
                            .Include("Certificate")
                            .Where(x => x.RecruiterId == recruiterId
                                && x.Activate == isActive
                                && x.FolderId == folderId);

            switch (sortColumn)
            {
                case "JobTitle":
                    if (sortType == "ASC")
                    {
                        query = query.OrderBy(x => x.JobTitle);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.JobTitle);
                    }
                    break;
                case "PostedDate":
                    if (sortType == "ASC")
                    {
                        query = query.OrderBy(x => x.PostedDate);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.PostedDate);
                    }
                    break;
                case "ClosedDate":
                    if (sortType == "ASC")
                    {
                        query = query.OrderBy(x => x.ClosedDate);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.ClosedDate);
                    }
                    break;
                default:
                    query = query.OrderByDescending(x => x.PostedDate).ThenByDescending(x => x.ClosedDate);
                    break;
            }

            totalRow = query.Count();
            var jobPostings = query.Skip(page * pageSize).Take(pageSize).ToList();
            var results = jobPostings.Select(x => new JobPostingDto
            {
                JobId = x.Id,
                JobNo = x.JobNo,
                JobTitle = x.JobTitle,
                CertificateName = x.Certificate.Name,
                CategoryName = x.JobCategory.Name,
                CloseDate = x.ClosedDate.ToString("dd/MM/yyyyy"),
                ClosedDate = x.ClosedDate,
                PostDate = x.PostedDate.ToString("dd/MM/yyyy"),
                PostedDate = x.PostedDate,
                RecruiterId = x.RecruiterId,
                RequiredNumber = x.RequiredNumber,
                ViewedNo = x.ViewedNo,
                Status = GetStatusByPostedDate(x.PostedDate),
                FolderId = x.FolderId
            }).ToList();
            return results;
        }

        private string GetStatusByPostedDate(DateTime postedDate)
        {
            if (postedDate.AddDays(30) < DateTime.Now)
            {
                return "Có";
            }
            else
            {
                return "Không";
            }
        }
    }
}
