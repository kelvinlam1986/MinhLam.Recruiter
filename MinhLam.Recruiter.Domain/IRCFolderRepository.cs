using MinhLam.Framework;
using System;
using System.Collections.Generic;

namespace MinhLam.Recruiter.Domain
{
    public interface IRCFolderRepository : IRepositoryBase<RCFolder>
    {
        List<RCFolder> GetListFolderOfRecruiter(Guid recruiterId);
    }
}
