using MinhLam.Recruiter.Application.Query.ViewModel;
using System;
using System.Collections.Generic;

namespace MinhLam.Recruiter.Application.Query
{
    public interface IJobPostingQuery
    {
         List<JobPostingDto> GetJobList(Guid recruiterId,
            bool isActive, Guid folderId, int page, int pageSize, 
            out int totalRow, string sortColumn = "", string sortType = "");

        List<JobDetailByRecruiterDto> GetJobDetailByRecruiter(Guid jobId, Guid recruiterId);
    }
}
