using MinhLam.Recruiter.Domain;

namespace MinhLam.Recruiter.Infrastructure.Repositories
{
    public class SalesPackageRepository : RepositoryBase<SalesPackage>, ISalesPackageRepository
    {
        public SalesPackageRepository(JobContext dbContext) : base(dbContext)
        {
        }
    }
}
