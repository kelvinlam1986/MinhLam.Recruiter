using System;
using System.Collections.Generic;

namespace MinhLam.Recruiter.Application.Commands
{
    public class RCAddSalesPackageCommand
    {
        public RCAddSalesPackageCommand(
            Guid recruiterId,
            string contactName,
            string paymentBy,
            string paymentCurrency)
        {
            RecruiterId = recruiterId;
            ContactName = contactName;
            PaymentBy = paymentBy;
            PaymentCurrency = paymentCurrency;
            PackageDetails = new List<RCSalesPackageDetailDto>();
        }

        public Guid RecruiterId { get; set; }
        public string ContactName { get; set; }
        public string PaymentBy { get; set; }
        public string PaymentCurrency { get; set; }
        public List<RCSalesPackageDetailDto> PackageDetails { get; set; }

        public void AddPackage(RCSalesPackageDetailDto packageDetail)
        {
            PackageDetails.Add(packageDetail);
        }

        public void RemovePackage(RCSalesPackageDetailDto packageDetail)
        {

        }

    }

    public class RCSalesPackageDetailDto
    {
        public RCSalesPackageDetailDto(Guid packageId, string packageName, int packageQuantity, int packagePrice, bool packageType)
        {
            PackageId = packageId;
            PackageName = packageName;
            PackageQuantity = packageQuantity;
            PackagePrice = packagePrice;
            PackageType = packageType;
        }

        public Guid PackageId { get; set; }
        public string PackageName { get; set; }
        public int PackageQuantity { get; set; }
        public int PackagePrice { get; set; }
        public bool PackageType { get; set; }
    }
}
