using System.Collections.Generic;

namespace MinhLam.Recruiter.Domain
{
    public interface IGetData
    {
        RCAccount GetRCAccountByEmail(string email);
        List<Province> GetProvinces();
    }
}
