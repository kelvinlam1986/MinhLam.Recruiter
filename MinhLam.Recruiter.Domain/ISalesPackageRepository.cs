using MinhLam.Framework;
using System;
using System.Collections.Generic;

namespace MinhLam.Recruiter.Domain
{
    public interface ISalesPackageRepository : IRepositoryBase<SalesPackage>
    {
        List<SalesPackageDetail> GetSalesPackageDetails(Guid salesPackageId);
        void RemoveSalesPackageDetail(SalesPackageDetail salesPackageDetail);
    }
}
