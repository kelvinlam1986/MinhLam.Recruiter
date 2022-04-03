using MinhLam.Recruiter.Application.Query.ViewModel;
using System;
using System.Collections.Generic;

namespace MinhLam.Recruiter.Application.Query
{
    public interface IFolderQuery
    {
        List<FolderDto> GetFolderList(Guid recruiterdId, string sortColumn = "", string sortType = "");
    }
}
