using System;
using System.Collections.Generic;

namespace MinhLam.Recruiter.Domain
{
    public interface IRCSavedSearchRepository
    {
        List<RCSavedSearch> GetListByRecruiterId(Guid recruiterId);
    }
}
