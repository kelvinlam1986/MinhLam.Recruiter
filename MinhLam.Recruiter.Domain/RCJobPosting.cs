﻿using MinhLam.Framework;
using System;

namespace MinhLam.Recruiter.Domain
{
    public class RCJobPosting : AggregateRoot
    {
        public Guid RecruiterId { get; protected set; }
        public string JobTitle { get; protected set; }
        public string JobNo { get; protected set; }
        public int RequiredNumber { get; protected set; }
        public string JobSummary { get; protected set; }
        public Guid WorkingTypeId { get; protected set; }
        public Guid ExperienceLevelId { get; protected set; }
        public string YearExperience { get; protected set; }
        public string RangeOfAge { get; protected set; }
        public string RecruitmentType { get; protected set; }
        public int SalaryFrom { get; protected set; }
        public int SalaryTo { get; protected set; }
        public string Currency { get; protected set; }
        public bool ShowSalary { get; protected set; }
        public bool SalaryNegotive { get; protected set; }
        public DateTime ClosedDate { get; protected set; }
        public bool CompanyLogo { get; protected set; }
        public string AdvName { get; protected set; }
        public string JobSkill { get; protected set; }
        public Guid JobIndustryId { get; protected set; }
        public Guid JobCategoryId { get; protected set; }
        public Guid CertificateId { get; protected set; }
        public string WorkLocation { get; protected set; }
        public Guid ProvinceId { get; protected set; }
        public Guid TemplateId { get; protected set; }
        public Guid FolderId { get; protected set; }
        public bool EnableApplyOnline { get; protected set; }
        public string OnlyApplyUrl { get; protected set; }
        public string ContactEmail { get; protected set; }
        public string ContactPerson { get; protected set; }
        public string ContactTel { get; protected set; }
        public int ViewedNo { get; protected set; }
        public DateTime PostedDate { get; protected set; }
        public DateTime UpdatedDate { get; protected set; }
        public bool Activate { get; protected set; }

        public static RCJobPosting New(
            Guid recruiterId,
            string jobTitle,
            string jobNo,
            int requiredNumber,
            string jobSummary,
            Guid workingTypeId,
            Guid experienceLevelId,
            string yearExperience,
            string rangeOfAge,
            string recruitmentType,
            int salaryFrom,
            int salaryTo,
            string currency,
            bool showSalary,
            bool salaryNegotive,
            DateTime closedDate,
            bool companyLogo,
            string advName,
            string jobSkill,
            Guid jobIndustryId,
            Guid jobCategoryId,
            Guid certificateId,
            string workLocation,
            Guid provinceId,
            Guid templateId,
            Guid folderId,
            bool enableApplyOnline,
            string onlyApplyUrl,
            string contactEmail,
            string contactPerson,
            string contactTel)
        {
            if (string.IsNullOrWhiteSpace(jobTitle))
            {
                throw new DomainException(DomainExceptionCode.JobTitleRequiredField,
                    "Bạn phải nhập tiêu đề tin công việc");
            }

            if (string.IsNullOrWhiteSpace(jobSummary))
            {
                throw new DomainException(DomainExceptionCode.JobSummaryRequiredField,
                    "Bạn phải nhập mô tả công việc");
            }

            if (jobCategoryId == null || jobCategoryId == Guid.Empty)
            {
                throw new DomainException(DomainExceptionCode.JobCategoryIdRequiredField,
                    "Bạn phải chọn ít nhất một thể loại công việc");
            }

            if (jobIndustryId == null || jobIndustryId == Guid.Empty)
            {
                throw new DomainException(DomainExceptionCode.JobIndustryIdRequiredField,
                   "Bạn phải chọn ít nhất một ngành công nghiệp");
            }

            if (certificateId == null || certificateId == Guid.Empty)
            {
                throw new DomainException(DomainExceptionCode.CertificateIdRequiredFiled,
                   "Bạn phải chọn ít nhất một chứng chỉ");
            }

            if (experienceLevelId == null || experienceLevelId == Guid.Empty)
            {
                throw new DomainException(DomainExceptionCode.ExperienceLevelIdRequiredFiekd,
                    "Bạn phải chọn ít nhất một mức kinh nghiệm");
            }

            if (string.IsNullOrWhiteSpace(yearExperience))
            {
                yearExperience = "0";
            }

            int numberOfYearExperience = 0;
            if (int.TryParse(yearExperience, out numberOfYearExperience) == false)
            {
                throw new DomainException(DomainExceptionCode.YearExperienceMustNumber,
                    "Số năm kinh nghiệp phải là số");
            }

            if (numberOfYearExperience > 20)
            {
                throw new DomainException(DomainExceptionCode.YearExperienceMustLessThan20,
                   "Số năm kinh nghiệp phải nhỏ hơn 20");
            }

            if (workingTypeId == null || workingTypeId == Guid.Empty)
            {
                throw new DomainException(DomainExceptionCode.WorkingTypeIdRequiredField,
                    "Bạn phải chọn một loại công việc");
            }

            if (requiredNumber < 1 && requiredNumber > 20)
            {
                throw new DomainException(DomainExceptionCode.RequiredNumberOutOfRange,
                    "Số lượng tuyển phải trong 1 đến 20");
            }

            if (string.IsNullOrWhiteSpace(currency))
            {
                throw new DomainException(DomainExceptionCode.CurrencyRequiredField,
                    "Bạn phải chọn một loại tiền tệ");
            }

            if (provinceId == null || provinceId == Guid.Empty)
            {
                throw new DomainException(DomainExceptionCode.ProvinceIdRequiredField,
                    "Bạn phải chọn một tỉnh thành");
            }

            if (folderId == null || folderId == Guid.Empty)
            {
                throw new DomainException(DomainExceptionCode.FolderIdRequiredField,
                    "Bạn phải chọn một thư mục");
            }

            if (templateId == null || templateId == Guid.Empty)
            {
                throw new DomainException(DomainExceptionCode.TemplateIdRequiredField,
                  "Bạn phải chọn một template");
            }

            var id = Guid.NewGuid();
            int viewedNo = 0;
            var postedDate = DateTime.Now;
            var updatedDate = DateTime.Now;
            bool activate = true;
            var jobPosting = new RCJobPosting(
                id,
                recruiterId,
                jobTitle,
                jobNo,
                requiredNumber,
                jobSummary,
                workingTypeId,
                experienceLevelId,
                yearExperience,
                rangeOfAge,
                recruitmentType,
                salaryFrom,
                salaryTo,
                currency,
                showSalary,
                salaryNegotive,
                closedDate,
                companyLogo,
                advName,
                jobSkill,
                jobIndustryId,
                jobCategoryId,
                certificateId,
                workLocation,
                provinceId,
                templateId,
                folderId,
                enableApplyOnline,
                onlyApplyUrl,
                contactEmail,
                contactPerson,
                contactTel,
                viewedNo,
                postedDate,
                updatedDate,
                activate);

            jobPosting.AddDomainEvents(
                new JobPostingAddedEvent(
                    recruiterId,
                    DecreaseAvaiablePostingOrViewingEnum.AvailableForPosting,
                    jobPosting.JobCategoryId, 
                    jobPosting.JobIndustryId,
                    jobPosting.Activate));
            return jobPosting;
        }

        internal RCJobPosting(
            Guid id,
            Guid recruiterId,
            string jobTitle,
            string jobNo,
            int requiredNumber,
            string jobSummary,
            Guid workingTypeId,
            Guid experienceLevelId,
            string yearExperience,
            string rangeOfAge,
            string recruitmentType,
            int salaryFrom,
            int salaryTo,
            string currency,
            bool showSalary,
            bool salaryNegotive,
            DateTime closedDate,
            bool companyLogo,
            string advName,
            string jobSkill,
            Guid jobIndustryId,
            Guid jobCategoryId,
            Guid certificateId,
            string workLocation,
            Guid provinceId,
            Guid templateId,
            Guid folderId,
            bool enableApplyOnline,
            string onlyApplyUrl,
            string contactEmail,
            string contactPerson,
            string contactTel,
            int viewedNo,
            DateTime postedDate,
            DateTime updatedDate,
            bool activate
            )
        {
            Id = id;
            RecruiterId = recruiterId;
            JobTitle = jobTitle;
            JobNo = jobNo;
            RequiredNumber = requiredNumber;
            JobSummary = jobSummary;
            WorkingTypeId = workingTypeId;
            ExperienceLevelId = experienceLevelId;
            YearExperience = yearExperience;
            RangeOfAge = rangeOfAge;
            RecruitmentType = recruitmentType;
            SalaryFrom = salaryFrom;
            SalaryTo = salaryTo;
            Currency = currency;
            ShowSalary = showSalary;
            SalaryNegotive = salaryNegotive;
            ClosedDate = closedDate;
            CompanyLogo = companyLogo;
            AdvName = advName;
            JobSkill = jobSkill;
            JobIndustryId = jobIndustryId;
            JobCategoryId = jobCategoryId;
            CertificateId = certificateId;
            WorkLocation = workLocation;
            ProvinceId = provinceId;
            TemplateId = templateId;
            FolderId = folderId;
            EnableApplyOnline = enableApplyOnline;
            OnlyApplyUrl = onlyApplyUrl;
            ContactEmail = contactEmail;
            ContactPerson = contactPerson;
            ContactTel = contactTel;
            ViewedNo = viewedNo;
            PostedDate = postedDate;
            UpdatedDate = updatedDate;
            Activate = activate;
        }

        public void UpdateJob(
            Guid recruiterId,
            string jobTitle,
            string jobNo,
            int requiredNumber,
            string jobSummary,
            Guid workingTypeId,
            Guid experienceLevelId,
            string yearExperience,
            string rangeOfAge,
            string recruitmentType,
            int salaryFrom,
            int salaryTo,
            string currency,
            bool showSalary,
            bool salaryNegotive,
            DateTime closedDate,
            bool companyLogo,
            string advName,
            string jobSkill,
            Guid jobIndustryId,
            Guid jobCategoryId,
            Guid certificateId,
            string workLocation,
            Guid provinceId,
            Guid templateId,
            Guid folderId,
            bool enableApplyOnline,
            string onlyApplyUrl,
            string contactEmail,
            string contactPerson,
            string contactTel)
        {
            this.RecruiterId = recruiterId;
            this.JobTitle = jobTitle;
            this.JobNo = jobNo;
            this.RequiredNumber = requiredNumber;
            this.JobSummary = jobSummary;
            this.WorkingTypeId = workingTypeId;
            this.ExperienceLevelId = experienceLevelId;
            this.YearExperience = yearExperience;
            this.RangeOfAge = rangeOfAge;
            this.RecruitmentType = recruitmentType;
            this.SalaryFrom = salaryFrom;
            this.SalaryTo = salaryTo;
            this.Currency = currency;
            this.ShowSalary = showSalary;
            this.SalaryNegotive = salaryNegotive;
            this.ClosedDate = closedDate;
            this.CompanyLogo = companyLogo;
            this.AdvName = advName;
            this.JobSkill = jobSkill;
            this.JobIndustryId = jobIndustryId;
            this.JobCategoryId = jobCategoryId;
            this.CertificateId = certificateId;
            this.WorkLocation = workLocation;
            this.ProvinceId = provinceId;
            this.TemplateId = templateId;
            this.FolderId = folderId;
            this.EnableApplyOnline = enableApplyOnline;
            this.OnlyApplyUrl = onlyApplyUrl;
            this.ContactEmail = contactEmail;
            this.ContactPerson = contactPerson;
            this.ContactTel = contactTel;
        }

        public void Remove()
        {

        }

        public void UpdateFolder(Guid folderId)
        {
            this.FolderId = folderId;
        }

        public void SetActivate()
        {
            this.Activate = true;
            this.UpdatedDate = DateTime.Now;
        }


    }
}

