using MinhLam.Recruiter.Application.Commands;
using MinhLam.Recruiter.Domain;

namespace MinhLam.Recruiter.Application
{
    public interface IMembershipService
    {
        void RCRegisterAccount(RCRegisterAccountCommand cmd);
        RCAccount GetRCAccountByEmail(string email);
        void RCLogin(RCLoginCommand cmd);
        void RCResetHitViewed(RCResetHitViewCommand cmd);
        void RCUpdateAccount(RCUpdateAccountCommand cmd);
        void RCUpdateCompany(RCUpdateCompanyCommand cmd);
    }
}
