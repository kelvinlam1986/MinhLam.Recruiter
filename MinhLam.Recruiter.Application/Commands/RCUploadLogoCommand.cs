using System;

namespace MinhLam.Recruiter.Application.Commands
{
    public class RCUploadLogoCommand
    {
        public RCUploadLogoCommand(Guid recruiterId)
        {
            RecruiterId = recruiterId;
        }

        public Guid RecruiterId { get; set; }
    }
}
