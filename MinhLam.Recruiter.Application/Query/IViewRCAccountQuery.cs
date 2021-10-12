using MinhLam.Recruiter.Application.Query.ViewModel;
using System;

namespace MinhLam.Recruiter.Application.Query
{
    public interface IViewRCAccountQuery
    {
        MyRCAccount GetMyRCAccount(Guid id);
    }
}
