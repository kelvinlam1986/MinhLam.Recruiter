using MinhLam.Recruiter.Application.Commands;

namespace MinhLam.Recruiter.Application
{
    public interface IFolderService
    {
        void AddNewFolder(AddNewFolderCommand cmd);
        void RemoveFolder(RCFolderRemoveCommand cmd);
    }
}
