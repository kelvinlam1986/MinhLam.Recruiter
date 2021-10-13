namespace MinhLam.Recruiter.Domain
{
    public class DomainExceptionCode
    {
        public const string RCAccountAlreadyExist = "rc_account_already_exisit";
        public const string EmailRequiredField = "email_required_field";
        public const string EmailIsNotCorrectFormat = "email_is_not_correct_format";
        public const string PasswordRequiredField = "password_required_field";
        public const string CompanyNameRequiredField = "company_name_required_field";
        public const string EnglishNameRequiredField = "english_name_required_field";
        public const string RCAccountCanNotFound = "rc_account_cannot_found";
        public const string ProvinceCannotFound = "province_cannot_found";
        public const string OldPasswordNotMatched = "old_password_not_matched";
        public const string PasswordNotMatched = "password_not_matched";
        public const string ContactRequiredField = "contact_required_field";
        public const string AddressRequiredField = "address_required_field";
        public const string TelephoneRequiredField = "telephone_required_field";
        public const string DateOfEstablihsedRequiredField = "date_of_established_required_field";
        public const string CannotGetOldPassword = "cannot_get_old_password";
    }
}
