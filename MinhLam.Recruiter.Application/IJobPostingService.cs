using MinhLam.Recruiter.Application.Commands;

namespace MinhLam.Recruiter.Application
{
    public interface IJobPostingService
    {
        void AddNewJobPosting(AddNewJobPostingCommand cmd);
        void UpdateJobPosting(UpdateJobPostingCommand cmd);
        void ToggleActive(ToggleActiveJobCommand cmd);
        void RemoveJobPostig(RCRemoveJobPostingCommand cmd);
        void UpdateFolder(RCUpdateFolderJobCommand cmd);
        void AddSalesPackage(RCAddSalesPackageCommand cmd);
    }
}
