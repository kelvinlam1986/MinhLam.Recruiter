using MinhLam.Framework;
using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Application.Commands;
using MinhLam.Recruiter.Domain;

namespace MinhLam.Recruiter.Infrastructure.Applications
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IRCJobPostingRepository jobPostingRepository;
        private readonly ISalesPackageRepository salesPackageRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICheckExisting checkExisting;
        private readonly IGetData getData;

        public JobPostingService(
            ICheckExisting checkExisting,
            IGetData getData,
            IRCJobPostingRepository jobPostingRepository,
            ISalesPackageRepository salesPackageRepository,
            IUnitOfWork unitOfWork)
        {
            this.checkExisting = checkExisting;
            this.getData = getData;
            this.jobPostingRepository = jobPostingRepository;
            this.salesPackageRepository = salesPackageRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddNewJobPosting(AddNewJobPostingCommand cmd)
        {
            var jobPosting = RCJobPosting.New(
                cmd.RecruiterId,
                cmd.JobTitle,
                cmd.JobNo,
                cmd.RequiredNumber,
                cmd.JobSummary,
                cmd.WorkingTypeId,
                cmd.ExperienceLevelId,
                cmd.YearExperience,
                cmd.RangeOfAge,
                cmd.RecruitementType,
                cmd.SalaryFrom,
                cmd.SalaryTo,
                cmd.Currency,
                cmd.ShowSalary,
                cmd.SalaryNegotiate,
                cmd.ClosedDate,
                cmd.CompanyLogo,
                cmd.AdvName,
                cmd.JobSkill,
                cmd.JobIndustryId,
                cmd.JobCategoryId,
                cmd.CertificateId,
                cmd.WorkLocation,
                cmd.ProvinceId,
                cmd.TemplateId,
                cmd.FolderId,
                cmd.EnableApplyOnline,
                cmd.OnlyApplyUrl,
                cmd.ContactEmail,
                cmd.ContactPerson,
                cmd.ContactTel);

            this.jobPostingRepository.Add(jobPosting);
            this.unitOfWork.Commit();
        }

        public void AddSalesPackage(RCAddSalesPackageCommand cmd)
        {
            var salesPackage = SalesPackage.New(cmd.RecruiterId, cmd.ContactName, cmd.PaymentBy, cmd.PaymentCurrency, checkExisting);
            foreach (var item in cmd.PackageDetails)
            {
                salesPackage.AddSalesPackageDetail(item.PackageId, item.PackageName, item.PackageQuantity, item.PackagePrice, item.PackageType, checkExisting, getData);
            }

            this.salesPackageRepository.Add(salesPackage);
            this.unitOfWork.Commit();
        }

        public void RemoveJobPostig(RCRemoveJobPostingCommand cmd)
        {
            var jobPosting = this.jobPostingRepository.GetById(cmd.JobId);
            if (jobPosting == null)
            {
                throw new ApplicationServiceException(
                    JobPostingExeptionCodes.CannotFoundJobPosting,
                    "Không tìm thấy tin");
            }

            this.jobPostingRepository.Remove(jobPosting);
            this.unitOfWork.Commit();
        }

        public void RemoveSalesPackage(RCRemoveSalesPackageCommand cmd)
        {
            var salesPackage = SalesPackage.InitForRemove(cmd.SalesPackageId, salesPackageRepository);
            salesPackage.Remove(salesPackageRepository, unitOfWork);
        }

        public void ToggleActive(ToggleActiveJobCommand cmd)
        {
            var jobPosting = this.jobPostingRepository.GetById(cmd.JobId);
            if (jobPosting == null)
            {
                throw new ApplicationServiceException(
                    JobPostingExeptionCodes.CannotFoundJobPosting,
                    "Không tìm thấy tin");
            }

            jobPosting.ToggleActive();
            this.jobPostingRepository.Update(jobPosting);
            this.unitOfWork.Commit();
        }

        public void UpdateFolder(RCUpdateFolderJobCommand cmd)
        {
            var jobPosting = this.jobPostingRepository.GetById(cmd.JobId);
            if (jobPosting == null)
            {
                throw new ApplicationServiceException(
                    JobPostingExeptionCodes.CannotFoundJobPosting,
                    "Không tìm thấy tin");
            }

            jobPosting.UpdateFolder(cmd.FolderId, checkExisting);
            this.jobPostingRepository.Update(jobPosting);
            this.unitOfWork.Commit();
        }

        public void UpdateJobPosting(UpdateJobPostingCommand cmd)
        {
            var jobPosting = this.jobPostingRepository.GetById(cmd.JobId);
            if (jobPosting == null)
            {
                throw new ApplicationServiceException(
                    JobPostingExeptionCodes.CannotFoundJobPosting,
                    "Không tìm thấy tin");
            }

            jobPosting.UpdateJob(
                cmd.RecruiterId,
                cmd.JobTitle,
                cmd.JobNo,
                cmd.RequiredNumber,
                cmd.JobSummary,
                cmd.WorkingTypeId,
                cmd.ExperienceLevelId,
                cmd.YearExperience,
                cmd.RangeOfAge,
                cmd.RecruitementType,
                cmd.SalaryFrom,
                cmd.SalaryTo,
                cmd.Currency,
                cmd.ShowSalary,
                cmd.SalaryNegotiate,
                cmd.ClosedDate,
                cmd.CompanyLogo,
                cmd.AdvName,
                cmd.JobSkill,
                cmd.JobIndustryId,
                cmd.JobCategoryId,
                cmd.CertificateId,
                cmd.WorkLocation,
                cmd.ProvinceId,
                cmd.TemplateId,
                cmd.FolderId,
                cmd.EnableApplyOnline,
                cmd.OnlyApplyUrl,
                cmd.ContactEmail,
                cmd.ContactPerson,
                cmd.ContactTel
                );
            this.jobPostingRepository.Update(jobPosting);
            this.unitOfWork.Commit();
        }
    }
}
