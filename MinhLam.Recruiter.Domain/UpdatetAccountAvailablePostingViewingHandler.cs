using MinhLam.Framework;

namespace MinhLam.Recruiter.Domain
{
    public class UpdatetAccountAvailablePostingViewingHandler : IHandler<JobPostingAddedEvent>
    {
        private IRCAccountRepository accountRepository;
        private ICheckExisting checkExisting;

        public UpdatetAccountAvailablePostingViewingHandler(
            IRCAccountRepository accountRepository,
            ICheckExisting checkExisting)
        {
            this.accountRepository = accountRepository;
            this.checkExisting = checkExisting;
        }

        public void Handle(JobPostingAddedEvent domainEvent)
        {
            var account = this.accountRepository.GetById(domainEvent.RecruiterId);
            if (account != null)
            {
                if (domainEvent.Type == DecreaseAvaiablePostingOrViewingEnum.AvailableForPosting)
                {
                    account.DecreaseAvailablePosting(checkExisting);
                }
                else if (domainEvent.Type == DecreaseAvaiablePostingOrViewingEnum.AvaliableForViewing)
                {
                    account.DecreaseAvailableViewing(checkExisting);
                }
            }

            accountRepository.Update(account);
        }
    }
}
