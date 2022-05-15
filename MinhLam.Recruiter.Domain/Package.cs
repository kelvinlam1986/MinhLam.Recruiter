using MinhLam.Framework;
using System;

namespace MinhLam.Recruiter.Domain
{
    public class Package : AggregateRoot
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Program { get; set; }
        public string Name { get; set; }
        public int MinQuantity { get; set; }
        public int MaxQuantity { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public string Currency { get; set; }
        public bool Type { get; set; }
        public bool Activate { get; set; }
        public DateTime EntryDate { get; set; }

        public Package()
        {
        }
    }
}
