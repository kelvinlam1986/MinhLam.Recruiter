using System;

namespace MinhLam.Recruiter.Application.Query.ViewModel
{
    public class FolderDto
    {
        public Guid FolderId { get; set; }
        public string FolderName { get; set; }
        public string FolderDescription { get; set; }
        public int Jobs { get; set; }
        public string FolderManager { get; set; }
    }
}
