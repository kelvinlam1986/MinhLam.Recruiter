using MinhLam.Framework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhLam.Recruiter.Domain
{
    public class SalesPackageDetail : Entity
    {
        public Guid SalesPackageId { get; protected set; }

        [ForeignKey("SalesPackageId")]
        public SalesPackage SalesPackage { get; protected set; }
        public string PackageName { get; protected set; }
        public int PackageQuantity { get; protected set; }
        public int PackagePrice { get; protected set; }
        public bool PackageType { get; protected set; }
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

        protected SalesPackageDetail()
        {
        }

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

    }
}
