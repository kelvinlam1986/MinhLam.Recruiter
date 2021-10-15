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
        public const string JobTitleRequiredField = "job_title_required_field";
        public const string JobSummaryRequiredField = "job_summary_required_field";
        public const string JobCategoryIdRequiredField = "job_category_id_required_field";
        public const string JobIndustryIdRequiredField = "job_industry_id_required_field";
        public const string CertificateIdRequiredFiled = "certificate_id_required_field";
        public const string ExperienceLevelIdRequiredFiekd = "experience_level_id_required_field";
        public const string YearExperienceMustNumber = "year_experience_must_number";
        public const string YearExperienceMustLessThan20 = "year_experience_must_less_20";
        public const string WorkingTypeIdRequiredField = "working_type_id_required_field";
        public const string RequiredNumberOutOfRange = "required_number_out_of_range";
        public const string CurrencyRequiredField = "currency_required_field";
        public const string ProvinceIdRequiredField = "province_id_required_field";
        public const string FolderIdRequiredField = "folder_id_required_field";
        public const string TemplateIdRequiredField = "template_id_required_field";
        public const string ContactEmailRequiredField = "contact_email_required_field";
        public const string ContactPersonRequiredField = "contact_person_required_field";
        public const string ContactTelRequiredField = "contact_tel_required_field";
    }
}
