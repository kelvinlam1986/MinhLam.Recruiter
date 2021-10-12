using System;
using System.Collections.Generic;

namespace MinhLam.Recruiter.Domain
{
    public interface IRCFolderRepository
    {
        List<RCFolder> GetListFolderOfRecruiter(Guid recruiterId);
    }
}
