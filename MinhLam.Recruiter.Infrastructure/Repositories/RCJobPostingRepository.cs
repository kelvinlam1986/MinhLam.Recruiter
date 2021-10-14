using MinhLam.Recruiter.Domain;

namespace MinhLam.Recruiter.Infrastructure.Repositories
{
    public class RCJobPostingRepository : RepositoryBase<RCJobPosting>, IRCJobPostingRepository
    {
        public RCJobPostingRepository(JobContext dbContext) : base(dbContext)
        {
        }
    }
}
