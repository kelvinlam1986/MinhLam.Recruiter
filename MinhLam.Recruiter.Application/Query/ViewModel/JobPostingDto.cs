using System;

namespace MinhLam.Recruiter.Application.Query.ViewModel
{
    public class JobPostingDto
    {
        public Guid JobId { get; set; }
        public string JobNo { get; set; }
        public string JobTitle { get; set; }
        public string CertificateName { get; set; }
        public string CategoryName { get; set; }
        public DateTime ClosedDate { get; set; }
        public string CloseDate { get; set; }
        public DateTime PostedDate { get; set; }
        public string PostDate { get; set; }
        public Guid RecruiterId { get; set; }
        public int RequiredNumber { get; set; }
        public int ViewedNo { get; set; }
        public string Status { get; set; }
        public Guid FolderId { get; set; }
    }
}
