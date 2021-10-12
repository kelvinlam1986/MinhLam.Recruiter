using MinhLam.Recruiter.Domain;
using System;

namespace MinhLam.Recruiter.Infrastructure.Repositories
{
    public class RCAccountRepository : RepositoryBase<RCAccount>, IRCAccountRepository
    {
        public RCAccountRepository(JobContext dbContext) : base(dbContext)
        {
        }
    }
}
