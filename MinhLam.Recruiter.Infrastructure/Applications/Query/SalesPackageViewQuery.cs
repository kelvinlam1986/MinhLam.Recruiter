using MinhLam.Recruiter.Application.Query;
using MinhLam.Recruiter.Application.Query.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MinhLam.Recruiter.Infrastructure.Applications.Query
{
    public class SalesPackageViewQuery : ISalesPackagesViewQuery
    {
        private readonly JobContext _jobContext;

        public SalesPackageViewQuery(JobContext jobContext)
        {
            _jobContext = jobContext;
        }

        public List<SalesPackageViewDto> GetList()
        {
            var packages = _jobContext.Packages.Where(x => x.Activate && DbFunctions.TruncateTime(x.EndDate) >= DbFunctions.TruncateTime(DateTime.Now)).ToList();
            var salesPackageDtos = packages.Select(x => new SalesPackageViewDto
            {
                PackageId = x.Id,
                Program = x.Program,
                Name = x.Name,
                MinQuantity = x.MinQuantity,
                MaxQuantity = x.MaxQuantity,
                MinMaxQuantity = x.MinQuantity.ToString().Trim() + "-" + x.MaxQuantity.ToString().Trim(),
                Package = x.Type ? "views" : "jobs",
                Price = x.Price,
                Discount = x.Discount,
                Currency = x.Currency,
                Type = x.Type
            }).ToList();

            return salesPackageDtos;
        }

        public List<SalesPackageViewDto> GetList(string columnName, string sortType)
        {
            var query = _jobContext.Packages.Where(x => x.Activate && DbFunctions.TruncateTime(x.EndDate) >= DbFunctions.TruncateTime(DateTime.Now));
            switch (columnName)
            {
                case "Program":
                    if (sortType == "ASC")
                    {
                        query = query.OrderBy(x => x.Program);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.Program);
                    }
                    break;
                case "Name":
                    if (sortType == "ASC")
                    {
                        query = query.OrderBy(x => x.Name);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.Name);
                    }
                    break;
                case "MinQuantity":
                    if (sortType == "ASC")
                    {
                        query = query.OrderBy(x => x.MinQuantity);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.MinQuantity);
                    }
                    break;
                case "MaxQuantity":
                    if (sortType == "ASC")
                    {
                        query = query.OrderBy(x => x.MaxQuantity);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.MaxQuantity);
                    }
                    break;
                case "Package":
                    if (sortType == "ASC")
                    {
                        query = query.OrderBy(x => x.Type);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.Type);
                    }
                    break;
                case "Price":
                    if (sortType == "ASC")
                    {
                        query = query.OrderBy(x => x.Price);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.Price);
                    }
                    break;
                case "Discount":
                    if (sortType == "ASC")
                    {
                        query = query.OrderBy(x => x.Discount);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.Discount);
                    }
                    break;
                case "Currency":
                    if (sortType == "ASC")
                    {
                        query = query.OrderBy(x => x.Currency);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.Currency);
                    }
                    break;
                default:
                    query = query.OrderByDescending(x => x.StartDate).ThenByDescending(x => x.EndDate);
                    break;
            }

            var salesPackageDtos = query.Select(x => new SalesPackageViewDto
            {
                PackageId = x.Id,
                Program = x.Program,
                Name = x.Name,
                MinQuantity = x.MinQuantity,
                MaxQuantity = x.MaxQuantity,
                MinMaxQuantity = x.MinQuantity.ToString().Trim() + "-" + x.MaxQuantity.ToString().Trim(),
                Package = x.Type ? "views" : "jobs",
                Price = x.Price,
                Discount = x.Discount,
                Currency = x.Currency,
                Type = x.Type
            }).ToList();

            return salesPackageDtos;
        }
    }
}
