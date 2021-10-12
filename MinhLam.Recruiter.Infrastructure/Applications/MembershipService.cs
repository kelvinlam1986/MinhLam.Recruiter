using MinhLam.Framework;
using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Application.Commands;
using MinhLam.Recruiter.Domain;
using System;

namespace MinhLam.Recruiter.Infrastructure.Applications
{
    public class MembershipService : IMembershipService
    {
        private IHashedPassword hashedPassword;
        private ICheckExisting checkExisting;
        private IRCAccountRepository accountRepository;
        private IGetData getData;
        private IUnitOfWork unitOfWork;

        public MembershipService(
            IHashedPassword hashedPassword,
            ICheckExisting checkExisting,
            IRCAccountRepository accountRepository,
            IGetData getData,
            IUnitOfWork unitOfWork)
        {
            this.hashedPassword = hashedPassword;
            this.checkExisting = checkExisting;
            this.accountRepository = accountRepository;
            this.getData = getData;
            this.unitOfWork = unitOfWork;
        }

        public RCAccount GetRCAccountByEmail(string email)
        {
            return this.getData.GetRCAccountByEmail(email);
        }

        public void RCLogin(RCLoginCommand cmd)
        {
            var loggedInAccount = RCAccount.Login(cmd.Email, cmd.PurePassword, hashedPassword, getData);
            this.accountRepository.Update(loggedInAccount);
            this.unitOfWork.Commit();
        }

        public void RCRegisterAccount(RCRegisterAccountCommand cmd)
        {
            var account = RCAccount.NewForRegister(
                cmd.Email,
                cmd.PurePassword,
                cmd.CompanyName,
                cmd.EnglishName,
                cmd.AccountType,
                cmd.Newsletter,
                cmd.ResumeAlert,
                cmd.Promotion,
                hashedPassword,
                checkExisting
                );
            this.accountRepository.Add(account);
            this.unitOfWork.Commit();
        }

        public void RCResetHitViewed(RCResetHitViewCommand cmd)
        {
            var account = this.accountRepository.GetById(cmd.RecruiterId);
            if (account == null)
            {
                throw new ApplicationServiceException(
                    MembershipExceptionCodes.CannotFoundRCAccount,
                    "Không thể tìm thấy tài khoản");
            }

            if (account.HitViewed > 0)
            {
                account.ResetHitViews(checkExisting);
                this.accountRepository.Update(account);
                this.unitOfWork.Commit();
            }
        }

        public void RCUpdateAccount(RCUpdateAccountCommand cmd)
        {
            var account = this.accountRepository.GetById(cmd.RecruiterId);
            if (account == null)
            {
                throw new ApplicationServiceException(
                    MembershipExceptionCodes.CannotFoundRCAccount,
                    "Không thể tìm thấy tài khoản");
            }

            account.UpdateAccount(
                cmd.CompanyName,
                cmd.EnglishName,
                cmd.AccountType,
                cmd.Newslettter,
                cmd.ResumeAlert,
                cmd.Promotion,
                checkExisting);

            this.accountRepository.Update(account);
            this.unitOfWork.Commit();
        }

        public void RCUpdateCompany(RCUpdateCompanyCommand cmd)
        {
            var account = this.accountRepository.GetById(cmd.RecruiterId);
            if (account == null)
            {
                throw new ApplicationServiceException(
                    MembershipExceptionCodes.CannotFoundRCAccount,
                    "Không thể tìm thấy tài khoản");
            }

            account.UpdateProfile(
                cmd.Contact, 
                cmd.Address, 
                cmd.Country, 
                cmd.Tel, 
                cmd.Fax, 
                cmd.ProvinceId, 
                cmd.City, 
                cmd.OpenDate, 
                checkExisting);

            this.accountRepository.Update(account);
            this.unitOfWork.Commit();
        }
    }
}
