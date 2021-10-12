using MinhLam.Recruiter.Application.Query;
using MinhLam.Recruiter.Application.Query.ViewModel;
using System;
using System.Linq;

namespace MinhLam.Recruiter.Infrastructure.Applications.Query
{
    public class ViewRCAccountQuery : IViewRCAccountQuery
    {
        private readonly JobContext context;

        public ViewRCAccountQuery(JobContext context)
        {
            this.context = context;
        }

        public MyRCAccount GetMyRCAccount(Guid id)
        {
            var result = new MyRCAccount();
            var account = this.context.RCAccounts.FirstOrDefault(x => x.Id == id);
            if (account != null)
            {
                result.RecruiterId = account.Id;
                result.Email = account.Email;
                result.CompanyName = account.CompanyName;
                result.EnglishName = account.EnglishName;
                result.AccountType = account.AccountType;
                result.Agency = account.Agency;
                result.RegisterDate = account.RegisterDate.ToString("dd/MM/yyyy");
                result.LastLogin = account.LastLogin.ToString("dd/MM/yyyy");
                result.JobPostingBalance = account.JobPostingBalance;
                result.ResumeViewingBalance = account.ResumeViewingBalance;
                result.AvailableForPosting = account.AvailableForPosting;
                result.AvailableForViewing = account.AvailableForViewing;
                result.HitViewed = account.HitViewed;
                result.Activate = account.Activate;
            }

            //var jobNo = this.context.RCJobPostings.Where(x => x.RecruiterId == id).Count();
            //result.JobNo = jobNo;

            return result;
        }
    }
}
