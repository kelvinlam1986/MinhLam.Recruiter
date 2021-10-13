using MinhLam.Framework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace MinhLam.Recruiter.Domain
{
    public class RCAccount : AggregateRoot
    {
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string CompanyName { get; protected set; }
        public string EnglishName { get; protected set; }
        public bool AccountType { get; protected set; }
        public bool Newsletter { get; protected set; }
        public bool ResumeAlert { get; protected set; }
        public bool Promotion { get; protected set; }
        public bool Logo { get; protected set; }
        public int JobPostingBalance { get; protected set; }
        public int ResumeViewingBalance { get; protected set; }
        public bool Activate { get; protected set; }
        public bool Agency { get; protected set; }
        public int AvailableForPosting { get; protected set; }
        public int AvailableForViewing { get; protected set; }
        public DateTime RegisterDate { get; protected set; }
        public DateTime LastLogin { get; protected set; }
        public int HitViewed { get; protected set; }
        public bool DefaultLanguage { get; protected set; }

        // Profile
        public string Contact { get; protected set; }
        public string Address { get; protected set; }
        public string Country { get; protected set; }
        public string Tel { get; protected set; }
        public string Fax { get; protected set; }
        public Guid? ProvinceId { get; protected set; }

        [ForeignKey("ProvinceId")]
        public Province Province { get; protected set; }

        public string City { get; protected set; }
        public DateTime? OpenDate { get; protected set; }

        public static RCAccount NewForRegister(
            string email,
            string purePassword,
            string companyName,
            string englishName,
            bool accountType,
            bool newsLetter,
            bool resumeAlert,
            bool promotion,
            IHashedPassword hashPasswordTool,
            ICheckExisting checkExisting)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException(
                    DomainExceptionCode.EmailRequiredField,
                    "Bạn phải nhập Email");
            }

            if (Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*") == false)
            {
                throw new DomainException(
                    DomainExceptionCode.EmailIsNotCorrectFormat,
                    "Email của bạn không đúng định dạng");
            }

            if (string.IsNullOrWhiteSpace(purePassword))
            {
                throw new DomainException(
                    DomainExceptionCode.PasswordRequiredField,
                    "Bạn phải nhập mật khẩu");
            }

            if (string.IsNullOrWhiteSpace(companyName))
            {
                throw new DomainException(
                    DomainExceptionCode.CompanyNameRequiredField,
                    "Bạn phải nhập Tên công ty");
            }

            if (string.IsNullOrWhiteSpace(englishName))
            {
                throw new DomainException(
                    DomainExceptionCode.EnglishNameRequiredField,
                    "Bạn phải nhập Tên công ty tiếng Anh");
            }

            var hashedPassword = hashPasswordTool.Hash(purePassword, email);
            if (checkExisting.RCAccountExistWithEmail(email))
            {
                throw new DomainException(
                    DomainExceptionCode.RCAccountAlreadyExist,
                    $"Tài khoản với {email} đã tồn tại");
            }

            // default for resiger
            bool logo = false;
            int jobPostingForBalance = 5;
            int resumeViewingBalance = 5;
            bool activate = false;
            bool agency = false;
            int availableForPosting = 5;
            int availableForViewing = 5;
            DateTime registerDate = DateTime.Now;
            DateTime lastLogin = DateTime.Now;
            int hitViewed = 0;
            bool defaultLanguage = false;
            return new RCAccount(
                Guid.NewGuid(),
                email,
                hashedPassword,
                companyName,
                englishName,
                accountType,
                newsLetter,
                resumeAlert,
                promotion,
                logo,
                jobPostingForBalance,
                resumeViewingBalance,
                activate,
                agency,
                availableForPosting,
                availableForViewing,
                registerDate,
                lastLogin,
                hitViewed,
                defaultLanguage
                );
        }

        protected RCAccount()
        {
        }

        internal RCAccount(
            Guid id,
            string email,
            string hashedPassword,
            string companyName,
            string englishName,
            bool accountType,
            bool newsLetter,
            bool resumeAlert,
            bool promotion,
            bool logo,
            int jobPostingBalance,
            int resumeViewingBalance,
            bool activate,
            bool agency,
            int availableForPosting,
            int availableForViewing,
            DateTime registerDate,
            DateTime lastLogin,
            int hitViewed,
            bool defaultLanguage
            )
        {
            Id = id;
            Email = email;
            Password = hashedPassword;
            CompanyName = companyName;
            EnglishName = englishName;
            AccountType = accountType;
            Newsletter = newsLetter;
            ResumeAlert = resumeAlert;
            Promotion = promotion;
            Logo = logo;
            JobPostingBalance = jobPostingBalance;
            ResumeViewingBalance = resumeViewingBalance;
            Activate = activate;
            Agency = agency;
            AvailableForPosting = availableForPosting;
            AvailableForViewing = availableForViewing;
            RegisterDate = registerDate;
            LastLogin = lastLogin;
            HitViewed = hitViewed;
            DefaultLanguage = defaultLanguage;
        }

        public void UpdateAccount(
            string companyName,
            string englishName,
            bool accountType,
            bool newsLetter,
            bool resumeAlert,
            bool promotion,
            ICheckExisting checkExisting)
        {
            if (checkExisting.RCAccountExistWithId(Id) == false)
            {
                throw new DomainException(
                    DomainExceptionCode.RCAccountCanNotFound,
                    $"Cannot found account with id {Id}");
            }

            if (checkExisting.RCAccountExistWithEmail(Email) == false)
            {
                throw new DomainException(
                   DomainExceptionCode.RCAccountCanNotFound,
                   $"Cannot found account with email {Email}");
            }

            if (string.IsNullOrWhiteSpace(companyName))
            {
                throw new DomainException(
                    DomainExceptionCode.CompanyNameRequiredField,
                    "Company name is required field");
            }

            if (string.IsNullOrWhiteSpace(englishName))
            {
                throw new DomainException(
                    DomainExceptionCode.EnglishNameRequiredField,
                    "English name is required field");
            }

            CompanyName = companyName;
            EnglishName = englishName;
            AccountType = accountType;
            Newsletter = newsLetter;
            ResumeAlert = resumeAlert;
            Promotion = promotion;
        }

        public void UpdateProfile(
            string contact,
            string address,
            string country,
            string tel,
            string fax,
            Guid provinceId,
            string city,
            DateTime openDate,
            ICheckExisting checkExisting)
        {
            if (checkExisting.RCAccountExistWithId(Id) == false)
            {
                throw new DomainException(
                    DomainExceptionCode.RCAccountCanNotFound,
                    $"Không tìm thấy tài khoản với id {Id}");
            }

            if (checkExisting.ProvinceExistsWithId(provinceId) == false)
            {
                throw new DomainException(
                    DomainExceptionCode.ProvinceCannotFound,
                    $"Không tìm thấy tỉnh thành với id {provinceId}");
            }

            if (string.IsNullOrWhiteSpace(contact))
            {
                throw new DomainException(
                    DomainExceptionCode.ContactRequiredField,
                    $"Bạn phải nhập tên liên hệ.");
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                throw new DomainException(
                    DomainExceptionCode.AddressRequiredField,
                    $"Bạn phải nhập địa chỉ liên hệ.");
            }

            if (string.IsNullOrWhiteSpace(Tel))
            {
                throw new DomainException(
                    DomainExceptionCode.TelephoneRequiredField,
                    $"Bạn phải nhập số điện thoại");
            }

            Contact = contact;
            Address = address;
            Country = country;
            Tel = tel;
            Fax = fax;
            ProvinceId = provinceId;
            City = city;
            OpenDate = openDate;
        }

        public void UploadLogo(ICheckExisting checkExisting)
        {
            if (checkExisting.RCAccountExistWithId(Id) == false)
            {
                throw new DomainException(
                    DomainExceptionCode.RCAccountCanNotFound,
                    $"Cannot found account with id {Id}");
            }

            Logo = true;
        }

        public void ResetHitViews(ICheckExisting checkExisting)
        {
            if (checkExisting.RCAccountExistWithId(Id) == false)
            {
                throw new DomainException(
                    DomainExceptionCode.RCAccountCanNotFound,
                    $"Cannot found account with id {Id}");
            }

            HitViewed = 0;
        }

        public void ChangePassword(
            string email, 
            string oldPassword, 
            string newPassword,
            IHashedPassword hashPasswordTool,
            ICheckExisting checkExisting)
        {
            if (checkExisting.RCAccountExistWithId(Id) == false)
            {
                throw new DomainException(
                    DomainExceptionCode.RCAccountCanNotFound,
                    $"Không tìm thấy tài khoản với id {Id}");
            }

            if (Email != email)
            {
                throw new DomainException(
                    DomainExceptionCode.RCAccountAlreadyExist,
                    $"Không tìm thấy tài khoản với email {email}");
            }

            var oldHashedPassword = hashPasswordTool.Hash(oldPassword, email);

            if (Password != oldHashedPassword)
            {
                throw new DomainException(
                    DomainExceptionCode.OldPasswordNotMatched,
                    $"Mật khẩu cũ không đúng.");
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                throw new DomainException(
                    DomainExceptionCode.PasswordRequiredField,
                    "Bạn phải nhập mật khẩu mới");
            }

            var hashedPassword = hashPasswordTool.Hash(newPassword, email);
            Password = hashedPassword;
        }

        public static string GetPassword(
            string email, 
            string companyName, 
            string englishName, 
            DateTime dateOfEstablished, 
            ICheckExisting checkExisting,
            IGetData getData,
            IHashedPassword hashedPassword)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException(
                    DomainExceptionCode.EmailRequiredField,
                    "Bạn phải nhập địa chỉ email");
            }

            if (string.IsNullOrWhiteSpace(companyName))
            {
                throw new DomainException(
                    DomainExceptionCode.CompanyNameRequiredField,
                    "Bạn phải nhập tên công ty");
            }

            if (string.IsNullOrWhiteSpace(englishName))
            {
                throw new DomainException(
                    DomainExceptionCode.EnglishNameRequiredField,
                    "Bạn phải nhập Tên tiếng Anh");
            }

            if (dateOfEstablished == null || dateOfEstablished == DateTime.MinValue)
            {
                throw new DomainException(
                    DomainExceptionCode.DateOfEstablihsedRequiredField,
                    "Bạn phải chọn ngày thành lập công ty");
            }

            if (checkExisting.RCAccountExistWithEmail(email) == false)
            {
                throw new DomainException(DomainExceptionCode.RCAccountCanNotFound,
                    $"Không tìm thấy tải khoản với email {email}");
            }

            var account = getData.GetRCAccountByEmail(email);
            if (account.Email == email 
                && account.CompanyName == companyName 
                && account.EnglishName == englishName 
                && account.OpenDate.Value.CompareOnlyDate(dateOfEstablished))
            {
                var oldPassword = hashedPassword.GetPurePassword(account.Password, account.Email);
                return oldPassword;
            }
            else
            {
                throw new DomainException(DomainExceptionCode.CannotGetOldPassword,
                    "Không thể lấy mật khẩu. Một trong những thông tin bạn cung cấp không đúng");
            }
        }

        public void DecreaseAvailablePosting(ICheckExisting checkExisting)
        {
            if (checkExisting.RCAccountExistWithId(Id) == false)
            {
                throw new DomainException(
                    DomainExceptionCode.RCAccountCanNotFound,
                    $"Cannot found account with id {Id}");
            }

            AvailableForPosting = AvailableForPosting - 1;
        }

        public void DecreaseAvailableViewing(ICheckExisting checkExisting)
        {
            if (checkExisting.RCAccountExistWithId(Id) == false)
            {
                throw new DomainException(
                    DomainExceptionCode.RCAccountCanNotFound,
                    $"Cannot found account with id {Id}");
            }

            AvailableForViewing = AvailableForViewing - 1;
        }

        public static RCAccount Login(
            string email, 
            string purePassword, 
            IHashedPassword hashedPassword,
            IGetData getData)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException(
                    DomainExceptionCode.EmailRequiredField,
                    "Bạn phải nhập Email.");
            }

            if (string.IsNullOrWhiteSpace(purePassword))
            {
                throw new DomainException(
                   DomainExceptionCode.PasswordRequiredField,
                   "Bạn phải nhập Mật khẩu.");
            }

            var account = getData.GetRCAccountByEmail(email);
            if (account == null)
            {
                throw new DomainException(
                    DomainExceptionCode.RCAccountCanNotFound,
                    "Xin kiểm tra lại Email với Mật khẩu.");
            }

            var passwordAfterHashed = hashedPassword.Hash(purePassword, email);
            if (account.Password != passwordAfterHashed)
            {
                throw new DomainException(
                   DomainExceptionCode.PasswordNotMatched,
                   "Xin kiểm tra lại Email với Mật khẩu.");
            }

            account.LastLogin = DateTime.Now;
            return account;
        }
    }

}

