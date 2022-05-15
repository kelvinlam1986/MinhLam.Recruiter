using MinhLam.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhLam.Recruiter.Domain
{
    public class SalesPackage : AggregateRoot
    {
        public static readonly string ATMTransfer = "ATM Transfer";
        public static readonly string Cash = "Cash";
        public static readonly string BankTransfer = "Bank Transfer";
        public static readonly string VND = "VND";
        public static readonly string USD = "USD";

        public static readonly List<string> PaymentTypes = new List<string> { ATMTransfer, Cash, BankTransfer };
        public static readonly List<string> PaymentCurrencies = new List<string> { VND, USD };

        public Guid RecruiterId { get; protected set; }

        [ForeignKey("RecruiterId")]
        public RCAccount Recruiter { get; set; }
        public string ContactName { get; protected set; }
        public DateTime OrderDate { get; protected set; }
        public string PaymentCurrency { get; protected set; }
        public string PaymentBy { get; protected set; }
        public bool PaidStatus { get; protected set; }
        public DateTime? PaidDate { get; protected set; }
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
            DateTime orderDate,
            bool paidStatus,
            List<SalesPackageDetail> salesPackageDetails
            )
        {
            Id = id;
            RecruiterId = recruiterId;
            ContactName = contactName;
            PaymentBy = paymentBy;
            PaymentCurrency = paymentCurrency;
            SalesPackageDetails = salesPackageDetails;
            OrderDate = orderDate;
            PaidStatus = paidStatus;
        }

        public static SalesPackage New(
            Guid recruiterId,
            string contactName,
            string paymentBy,
            string paymentCurrency,
            ICheckExisting checkExisting)
        {
            if (recruiterId == Guid.Empty)
            {
                throw new DomainException(DomainExceptionCode.RecruiterIdRequiredField, "Bạn phải chọn một nhà tuyển dụng");
            }

            bool isExisting = checkExisting.RCAccountExistWithId(recruiterId);
            if (isExisting == false)
            {
                throw new DomainException(DomainExceptionCode.RCAccountCanNotFound, "Nhà tuyển dụng này không tồn tại");
            }

            if (string.IsNullOrEmpty(contactName))
            {
                throw new DomainException(DomainExceptionCode.ContactRequiredField, "Bạn phải nhập tên người liên hệ");
            }

            if (string.IsNullOrEmpty(paymentBy))
            {
                throw new DomainException(DomainExceptionCode.PaymentByRequiredField, "Bạn phải nhập phương thức thanh toán");
            }

            if (PaymentTypes.Contains(paymentBy) == false)
            {
                throw new DomainException(DomainExceptionCode.PaymentTypeInvalid, "Phương thức thanh toán không hợp lệ");
            }

            if (string.IsNullOrEmpty(paymentCurrency))
            {
                throw new DomainException(DomainExceptionCode.PaymentCurrencyRequiredField, "Bạn phải chọn loại tiền tệ");
            }

            if (PaymentCurrencies.Contains(paymentCurrency) == false)
            {
                throw new DomainException(DomainExceptionCode.PaymentCurrencyInvalid, "Loại tiền tệ không hợp lệ");
            }

            var id = Guid.NewGuid();
            var orderDate = DateTime.Now;
            var paidStatus = false;
            var salesPackageDetailes = new List<SalesPackageDetail>();

            return new SalesPackage(
                id, recruiterId, contactName, paymentBy, paymentCurrency, orderDate, paidStatus, salesPackageDetailes);
        }


        public static SalesPackage InitForRemove(Guid salesPackageId, ISalesPackageRepository salesPackageRepository)
        {
            if (salesPackageId == Guid.Empty)
            {
                throw new DomainException(DomainExceptionCode.SalesPackageNotFound, "Không tìm thấy gói");
            }

            var salesPackage = salesPackageRepository.GetById(salesPackageId);
            if (salesPackage == null)
            {
                throw new DomainException(DomainExceptionCode.SalesPackageNotFound, "Không tìm thấy gói");
            }

            return salesPackage;
        }

        public void AddSalesPackageDetail(
            Guid packageId,
            string packageName, 
            int packageQuantity, 
            int packagePrice, 
            bool packageType,
            ICheckExisting checkExisting,
            IGetData getData)
        {
            var newSalesPackageDetail = SalesPackageDetail.New(
                Id,
                packageId,
                packageName,
                packageQuantity,
                packagePrice,
                packageType,
                checkExisting,
                getData
                );
            SalesPackageDetails.Add(newSalesPackageDetail);
        }

        public void Remove(ISalesPackageRepository salesPackageRepository, IUnitOfWork unitOfWork)
        {
            var salesPackageDetails = salesPackageRepository.GetSalesPackageDetails(this.Id);
            foreach (var salesPackageDetail in salesPackageDetails)
            {
                salesPackageRepository.RemoveSalesPackageDetail(salesPackageDetail);
            }
            salesPackageRepository.Remove(this);
            unitOfWork.Commit();
        }

    }
}
