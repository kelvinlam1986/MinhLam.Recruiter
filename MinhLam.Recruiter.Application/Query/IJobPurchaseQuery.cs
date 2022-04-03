using MinhLam.Recruiter.Application.Query.ViewModel;
using System;
using System.Collections.Generic;

namespace MinhLam.Recruiter.Application.Query
{
    public interface IJobPurchaseQuery
    {
        List<JobPurchaseDto> GetJobPurchaseList(Guid recruiterId, int page, int pageSize,
            out int totalRow, string sortColumn = "", string sortType = "");
    }
}
