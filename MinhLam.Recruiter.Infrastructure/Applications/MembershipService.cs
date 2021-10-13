using MinhLam.Framework;
using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Application.Commands;
using MinhLam.Recruiter.Domain;

namespace MinhLam.Recruiter.Infrastructure.Applications
{
    public class MembershipService : IMembershipService
    {
        private IHashedPassword hashedPassword;
        private ICheckExisting checkExisting;
        private IRCAccountRepository accountRepository;
        private IGetData getData;
        private IUnitOfWork unitOfWork;
        private ISendEmail sendEmail;

        public MembershipService(
            IHashedPassword hashedPassword,
            ICheckExisting checkExisting,
            IRCAccountRepository accountRepository,
            IGetData getData,
            IUnitOfWork unitOfWork,
            ISendEmail sendEmail)
        {
            this.hashedPassword = hashedPassword;
            this.checkExisting = checkExisting;
            this.accountRepository = accountRepository;
            this.getData = getData;
            this.unitOfWork = unitOfWork;
            this.sendEmail = sendEmail;
        }

        public RCAccount GetRCAccountByEmail(string email)
        {
            return this.getData.GetRCAccountByEmail(email);
        }

        public void RCChangePassword(RCChangePasswordCommand cmd)
        {
            var account = this.accountRepository.GetById(cmd.RecruiterId);
            if (account == null)
            {
                throw new ApplicationServiceException(
                    MembershipExceptionCodes.CannotFoundRCAccount,
                    "Không thể tìm thấy tài khoản");
            }
           
            account.ChangePassword(cmd.Email, cmd.OldPassword, cmd.NewPassword, hashedPassword, checkExisting);
            this.accountRepository.Update(account);
            this.unitOfWork.Commit();
            this.sendEmail.SendChangePasswordSuccessfulRCAccount(cmd.Email);
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

        public void RCUploadLogo(RCUploadLogoCommand cmd)
        {
            var account = this.accountRepository.GetById(cmd.RecruiterId);
            if (account == null)
            {
                throw new ApplicationServiceException(
                    MembershipExceptionCodes.CannotFoundRCAccount,
                    "Không thể tìm thấy tài khoản");
            }

            account.UploadLogo(checkExisting);
            this.accountRepository.Update(account);
            this.unitOfWork.Commit();
        }
    }
}
