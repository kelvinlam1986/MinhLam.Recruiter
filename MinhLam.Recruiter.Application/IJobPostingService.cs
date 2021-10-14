using MinhLam.Recruiter.Application.Commands;

namespace MinhLam.Recruiter.Application
{
    public interface IJobPostingService
    {
        void AddNewJobPosting(AddNewJobPostingCommand cmd);
    }
}
