using System;

namespace MinhLam.Recruiter.Application.Commands
{
    public class RCRemoveSalesPackageCommand
    {
        public RCRemoveSalesPackageCommand(Guid salesPackageId)
        {
            SalesPackageId = salesPackageId;
        }

        public Guid SalesPackageId { get; set; }
    }
}
