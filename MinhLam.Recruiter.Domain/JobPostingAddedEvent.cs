using MinhLam.Framework;
using System;

namespace MinhLam.Recruiter.Domain
{
    public class JobPostingAddedEvent : IDomainEvent
    {
        public JobPostingAddedEvent(
           Guid recruiterId,
           DecreaseAvaiablePostingOrViewingEnum type,
           Guid caterogyId,
           Guid industryId,
           bool activate)
        {
            RecruiterId = recruiterId;
            Type = type;
            CategoryId = caterogyId;
            IndustryId = industryId;
            Activate = activate;
        }

        public Guid RecruiterId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid IndustryId { get; set; }
        public bool Activate { get; set; }
        public DecreaseAvaiablePostingOrViewingEnum Type { get; set; }
    }
}
