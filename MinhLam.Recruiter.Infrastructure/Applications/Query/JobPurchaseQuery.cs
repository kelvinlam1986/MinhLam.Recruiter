using MinhLam.Recruiter.Application.Query;
using MinhLam.Recruiter.Application.Query.ViewModel;
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
            //switch (sortColumn)
            //{
            //    case "JobTitle":
            //        if (sortType == "ASC")
            //        {
            //            query = query.OrderBy(x => x.JobTitle);
            //        }
            //        else
            //        {
            //            query = query.OrderByDescending(x => x.JobTitle);
            //        }
            //        break;
            //    case "PostedDate":
            //        if (sortType == "ASC")
            //        {
            //            query = query.OrderBy(x => x.PostedDate);
            //        }
            //        else
            //        {
            //            query = query.OrderByDescending(x => x.PostedDate);
            //        }
            //        break;
            //    case "ClosedDate":
            //        if (sortType == "ASC")
            //        {
            //            query = query.OrderBy(x => x.ClosedDate);
            //        }
            //        else
            //        {
            //            query = query.OrderByDescending(x => x.ClosedDate);
            //        }
            //        break;
            //    default:
            //        query = query.OrderByDescending(x => x.PostedDate).ThenByDescending(x => x.ClosedDate);
            //        break;
            //}

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
                PaymentBy = salesPackage.PaymentBy,
                Status = salesPackage.PaidStatus ? "1" : "0",
                PaidDate = salesPackage.PaidDate.ToString("dd/MM/yyyy")
            }).ToList();

            return results;
        }
    }
}
