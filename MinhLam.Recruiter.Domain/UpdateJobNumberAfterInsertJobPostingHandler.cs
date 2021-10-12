using MinhLam.Framework;

namespace MinhLam.Recruiter.Domain
{
    public class UpdateJobNumberAfterInsertJobPostingHandler : IHandler<JobPostingAddedEvent>
    {
        private IJobCategoryRepository jobCategoryRepository;
        private IJobIndustryRepository jobIndustryRepository;

        public UpdateJobNumberAfterInsertJobPostingHandler(
            IJobCategoryRepository jobCategoryRepository,
            IJobIndustryRepository jobIndustryRepository)
        {
            this.jobCategoryRepository = jobCategoryRepository;
            this.jobIndustryRepository = jobIndustryRepository;
        }

        public void Handle(JobPostingAddedEvent domainEvent)
        {
            var jobCategory = jobCategoryRepository.GetById(domainEvent.CategoryId);
            if (jobCategory != null)
            {
                jobCategory.IncreaseJobNumber();
                jobCategoryRepository.Update(jobCategory);
            }

            var jobIndustry = jobIndustryRepository.GetById(domainEvent.IndustryId);
            if (jobIndustry != null)
            {
                jobIndustry.IncreaseJobNumber();
                jobIndustryRepository.Update(jobIndustry);
            }
        }
    }
}
