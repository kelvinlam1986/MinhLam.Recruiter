using MinhLam.Recruiter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhLam.Recruiter.Infrastructure.Repositories
{
    public class SalesPackageRepository : RepositoryBase<SalesPackage>, ISalesPackageRepository
    {
        public SalesPackageRepository(JobContext dbContext) : base(dbContext)
        {
        }

        public List<SalesPackageDetail> GetSalesPackageDetails(Guid salesPackageId)
        {
            return DbContext.SalesPackageDetails.Where(x => x.SalesPackageId == salesPackageId).ToList();
        }

        public void RemoveSalesPackageDetail(SalesPackageDetail salesPackageDetail)
        {
            DbContext.SalesPackageDetails.Remove(salesPackageDetail);
        }
    }
}
