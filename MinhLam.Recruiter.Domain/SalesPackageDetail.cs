using MinhLam.Framework;
using System;

namespace MinhLam.Recruiter.Domain
{
    public class SalesPackageDetail : Entity
    {
        public Guid SalesPackageId { get; protected set; }
        public string PackageName { get; protected set; }
        public int PackageQuantity { get; protected set; }
        public int PackagePrice { get; protected set; }
        public bool PackageType { get; protected set; }

        public static SalesPackageDetail New(
            Guid salesPackageId, 
            string packageName, 
            int packageQuantity, 
            int packagePrice, 
            bool packageType)
        {
            var id = Guid.NewGuid();
            return new SalesPackageDetail(
                id, salesPackageId, packageName, packageQuantity, packagePrice, packageType);
        }

        protected SalesPackageDetail(
            Guid id, 
            Guid salesPackageId, 
            string packageName, 
            int packageQuantity,
            int packagePrice,
            bool packageType)
        {
            this.Id = id;
            this.SalesPackageId = salesPackageId;
            this.PackageName = packageName;
            this.PackageQuantity = packageQuantity;
            this.PackagePrice = packagePrice;
            this.PackageType = packageType;
        }
    }
}
