using MinhLam.Recruiter.Application.Query;
using MinhLam.Recruiter.Application.Query.ViewModel;
using MinhLam.Recruiter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhLam.Recruiter.Infrastructure.Applications.Query
{
    public class JobPurchaseQuery : IJobPurchaseQuery
    {
        private readonly JobContext jobContext;

        public JobPurchaseQuery(JobContext context)
        {
            this.jobContext = context;
        }

        public List<JobPurchaseDto> GetJobPurchaseList(Guid recruiterId, int page, int pageSize, out int totalRow, string sortColumn = "", string sortType = "")
        {
            totalRow = 0;
            var query = jobContext.SalesPackage
                            .Include("SalesPackageDetails")
                            .Include("Recruiter")
                            .Where(x => x.RecruiterId == recruiterId)
                            .OrderByDescending(x => x.OrderDate);
            switch (sortColumn)
            {
                case "ContactName":
                    if (sortType == "ASC")
                    {
                        query = query.OrderBy(x => x.ContactName);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.ContactName);
                    }
                    break;
                case "OrderDate":
                    if (sortType == "ASC")
                    {
                        query = query.OrderBy(x => x.OrderDate);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.OrderDate);
                    }
                    break;
                default:
                    query = query.OrderByDescending(x => x.OrderDate);
                    break;
            }

            totalRow = query.Count();
            var jobPostings = query.Skip(page * pageSize).Take(pageSize).ToList();
            var results = jobPostings.SelectMany(x => x.SalesPackageDetails, (salesPackage, salesPackageDetail) => new JobPurchaseDto
            {
                PackageId = salesPackage.Id,
                RecruiterId = salesPackage.RecruiterId,
                ContactName = salesPackage.ContactName,
                CompanyName = salesPackage.Recruiter.CompanyName,
                OrdersDate = salesPackage.OrderDate.ToString("dd/MM/yyyy"),
                OrderDate = salesPackage.OrderDate,
                Quantity = salesPackageDetail.PackageQuantity,
                Package = salesPackageDetail.PackageType == false ? "job(s)" : "resume view(s)",
                Price = salesPackageDetail.PackagePrice,
                PackageName = salesPackageDetail.PackageName,
                Currency = salesPackage.PaymentCurrency,
                PaymentBy = ConvertPaymentByToVietnamese(salesPackage.PaymentBy),
                Status = salesPackage.PaidStatus ? "Đã thanh toán" : "Chưa thanh toán",
                PaidDate = salesPackage.PaidDate.HasValue ? salesPackage.PaidDate.Value.ToString("dd/MM/yyyy") : string.Empty
            }).ToList();

            return results;
        }

        public string ConvertPaymentByToVietnamese(string paymentBy)
        {
            switch (paymentBy)
            {
                case "ATM Transfer":
                    return "Chuyển khoản ATM";
                case "Cash":
                    return "Tiền mặt";
                case "Bank Transfer":
                    return "Chuyển khoản ngân hàng";
                default:
                    return string.Empty;
            }
        }
    }
}
