using MinhLam.Framework;
using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Application.Commands;
using MinhLam.Recruiter.Domain;

namespace MinhLam.Recruiter.Infrastructure.Applications
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IRCJobPostingRepository jobPostingRepository;
        private readonly IUnitOfWork unitOfWork;

        public JobPostingService(
            IRCJobPostingRepository jobPostingRepository,
            IUnitOfWork unitOfWork)
        {
            this.jobPostingRepository = jobPostingRepository;
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
