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
