using System;

namespace MinhLam.Recruiter.Application.Query.ViewModel
{
    public class JobPurchaseDto
    {
        public Guid PackageId { get; set; }
        public Guid RecruiterId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrdersDate { get; set; }
        public int Quantity { get; set; }
        public string Package { get; set; }
        public int Price { get; set; }
        public string PackageName { get; set; }
        public string Currency { get; set; }
        public string PaymentBy { get; set; }
        public string Status { get; set; }
        public string PaidDate { get; set; }
    }
}
