using MinhLam.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhLam.Recruiter.Domain
{
    public class SalesPackage : AggregateRoot
    {
        public Guid RecruiterId { get; protected set; }

        [ForeignKey("RecruiterId")]
        public RCAccount Recruiter { get; set; }
        public string ContactName { get; protected set; }
        public DateTime OrderDate { get; protected set; }
        public string PaymentCurrency { get; protected set; }
        public string PaymentBy { get; protected set; }
        public bool PaidStatus { get; protected set; }
        public DateTime PaidDate { get; protected set; }
        public List<SalesPackageDetail> SalesPackageDetails { get; protected set;  }

        public SalesPackage()
        {
        }

        internal SalesPackage(
            Guid id,
            Guid recruiterId,
            string contactName,
            string paymentBy,
            string paymentCurrency,
            List<SalesPackageDetail> salesPackageDetails
            )
        {
            Id = id;
            RecruiterId = recruiterId;
            ContactName = contactName;
            PaymentBy = paymentBy;
            PaymentCurrency = paymentCurrency;
            SalesPackageDetails = salesPackageDetails;
        }

        public static SalesPackage New(
            Guid recruiterId,
            string contactName,
            string paymentBy,
            string paymentCurrency)
        {
            var id = Guid.NewGuid();
            var salesPackageDetailes = new List<SalesPackageDetail>();

            return new SalesPackage(
                id, recruiterId, contactName, paymentBy, paymentCurrency, salesPackageDetailes);
        }


        public void AddSalesPackageDetail(
            string packageName, 
            int packageQuantity, 
            int packagePrice, 
            bool packageType)
        {
            var newSalesPackageDetail = SalesPackageDetail.New(
                Id,
                packageName,
                packageQuantity,
                packagePrice,
                packageType);
            SalesPackageDetails.Add(newSalesPackageDetail);
        }
    }
}
