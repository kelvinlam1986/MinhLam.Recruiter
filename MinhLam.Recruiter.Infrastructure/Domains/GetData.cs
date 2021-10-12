using MinhLam.Recruiter.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MinhLam.Recruiter.Infrastructure.Domains
{
    public class GetData : IGetData
    {
        private readonly JobContext context;

        public GetData(JobContext context)
        {
            this.context = context;
        }

        public List<Province> GetProvinces()
        {
            return this.context.Provinces.ToList();
        }

        public RCAccount GetRCAccountByEmail(string email)
        {
            return this.context.RCAccounts.FirstOrDefault(x => x.Email == email);
        }
    }
}
