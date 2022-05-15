using MinhLam.Recruiter.Application.Query.ViewModel;
using System.Collections.Generic;

namespace MinhLam.Recruiter.Application.Query
{
    public interface ISalesPackagesViewQuery
    {
        List<SalesPackageViewDto> GetList();
        List<SalesPackageViewDto> GetList(string columnName, string sortType);
    }
}
