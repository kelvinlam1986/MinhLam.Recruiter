using System;

namespace MinhLam.Recruiter.Application.Query.ViewModel
{
    public class SalesPackageViewDto
    {
        public Guid PackageId { get; set; }
        public string Program { get; set; }
        public string Name { get; set; }
        public int MinQuantity { get; set; }
        public int MaxQuantity { get; set; }
        public string MinMaxQuantity { get; set; }
        public string Package { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public string Currency { get; set; }
        public bool Type { get; set; }

    }
}
