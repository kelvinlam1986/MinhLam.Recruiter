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
            Guid packageId,
            string packageName, 
            int packageQuantity, 
            int packagePrice, 
            bool packageType,
            ICheckExisting checkExisting,
            IGetData getData)
        {
            if (salesPackageId == Guid.Empty)
            {
                throw new DomainException(DomainExceptionCode.SalesPackageIdRequiredField, "Đơn hàng không tồn tại");
            }

            bool isPackageExisting = checkExisting.PackageExistsWithId(packageId);
            if (isPackageExisting == false)
            {
                throw new DomainException(DomainExceptionCode.CannotFoundPackage, "Không tìm thấy gói");
            }

            if (string.IsNullOrEmpty(packageName))
            {
                throw new DomainException(DomainExceptionCode.PackageNameRequiredField, "Tên gói hàng không thể rỗng");
            }

            var package = getData.GetPackageById(packageId);
            if (packageName != package.Name)
            {
                throw new DomainException(DomainExceptionCode.PackageNameInvalid, "Tên gói hàng không trùng khớp");
            }

            if (packageQuantity < 0)
            {
                throw new DomainException(DomainExceptionCode.PackageQuantityInvalid, "Số lượng phải lớn hơn 0");
            }

            if (packageQuantity < package.MinQuantity || packageQuantity > package.MaxQuantity)
            {
                throw new DomainException(DomainExceptionCode.PackageNameInvalid, 
                    $"Số lượng phải lớn hơn hoặc bằng {package.MinQuantity} và nhỏ hơn hoặc bằng {package.MaxQuantity}");
            }

            if (packagePrice <= 0)
            {
                throw new DomainException(DomainExceptionCode.PackagePriceInvalid, "Đơn giá phải lớn hơn 0");
            }

            if (packagePrice != package.Price)
            {
                throw new DomainException(DomainExceptionCode.PackagePriceInvalid, "Đơn giá không trùng khớp");
            }

            if (packageType != package.Type)
            {
                throw new DomainException(DomainExceptionCode.PackageTypeInvalid, "Loại gói hàng không trùng khớp");
            }

            var id = Guid.NewGuid();
            return new SalesPackageDetail(
                id, salesPackageId, packageName, packageQuantity, packagePrice, packageType);
        }
    }
}
