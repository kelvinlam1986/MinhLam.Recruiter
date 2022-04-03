using MinhLam.Recruiter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhLam.Recruiter.Infrastructure.Repositories
{
    public class RCFolderRepository : RepositoryBase<RCFolder>, IRCFolderRepository
    {
        public RCFolderRepository(JobContext dbContext) : base(dbContext)
        {
        }

        public List<RCFolder> GetListFolderOfRecruiter(Guid recruiterId)
        {
            return DbContext.RCFolders.Where(x => x.RecruiterId == recruiterId).ToList();
        }
    }
}
