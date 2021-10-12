using System;

namespace MinhLam.Recruiter.Application.Commands
{
    public class RCUpdateCompanyCommand
    {
        public RCUpdateCompanyCommand(
            Guid recruiterId,
            string contact,
            string address,
            Guid provinceId,
            string city,
            DateTime openDate,
            string tel,
            string fax,
            string country)
        {
            RecruiterId = recruiterId;
            Contact = contact;
            Address = address;
            ProvinceId = provinceId;
            City = city;
            OpenDate = openDate;
            Tel = tel;
            Fax = fax;
            Country = country;
        }

        public Guid RecruiterId { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public Guid ProvinceId { get; set; }
        public string City { get; set; }
        public DateTime OpenDate { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Country { get; set; }
    }
}
