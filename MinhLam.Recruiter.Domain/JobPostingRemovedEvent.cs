using MinhLam.Framework;
using System;

namespace MinhLam.Recruiter.Domain
{
    public class JobPostingRemovedEvent : IDomainEvent
    {
        public JobPostingRemovedEvent(Guid categoryId, Guid industryId)
        {
            CategoryId = categoryId;
            IndustryId = industryId;
        }

        public Guid CategoryId { get; set; }
        public Guid IndustryId { get; set; }
    }
}
