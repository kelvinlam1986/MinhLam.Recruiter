using MinhLam.Framework;

namespace MinhLam.Recruiter.Domain
{
    public class UpdateJobNumberAfterRemoveJobPostingHandler : IHandler<JobPostingRemovedEvent>
    {
        private IJobCategoryRepository jobCategoryRepository;
        private IJobIndustryRepository jobIndustryRepository;

        public UpdateJobNumberAfterRemoveJobPostingHandler(
            IJobCategoryRepository jobCategoryRepository,
            IJobIndustryRepository jobIndustryRepository)
        {
            this.jobCategoryRepository = jobCategoryRepository;
            this.jobIndustryRepository = jobIndustryRepository;
        }

        public void Handle(JobPostingRemovedEvent domainEvent)
        {
            var jobCategory = jobCategoryRepository.GetById(domainEvent.CategoryId);
            if (jobCategory != null)
            {
                jobCategory.DecreaseJobNumber();
                jobCategoryRepository.Update(jobCategory);
            }

            var jobIndustry = jobIndustryRepository.GetById(domainEvent.IndustryId);
            if (jobIndustry != null)
            {
                jobIndustry.DecreaseJobNumber();
                jobIndustryRepository.Update(jobIndustry);
            }
        }
    }
}
