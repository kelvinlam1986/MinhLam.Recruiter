using MinhLam.Framework;
using MinhLam.Recruiter.Application;
using MinhLam.Recruiter.Application.Commands;
using MinhLam.Recruiter.Domain;
using System;

namespace MinhLam.Recruiter.Infrastructure.Applications
{
    public class FolderService : IFolderService
    {
        private readonly ICheckExisting _checkExisting;
        private readonly IRCFolderRepository _folderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FolderService(
            ICheckExisting checkExisting,
            IRCFolderRepository folderRepository,
            IUnitOfWork unitOfWork)
        {
            _checkExisting = checkExisting;
            _folderRepository = folderRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddNewFolder(AddNewFolderCommand cmd)
        {
            var folder = RCFolder.New(
                cmd.RecruiterId,
                cmd.FolderName,
                cmd.FolderDescription,
                cmd.FolderManager,
                _checkExisting,
                _folderRepository);

            _folderRepository.Add(folder);
            _unitOfWork.Commit();

        }

        public void RemoveFolder(RCFolderRemoveCommand cmd)
        {
            var folder = RCFolder.NewFromRemove(
                cmd.FolderId,
                _checkExisting,
                _folderRepository);

            _folderRepository.Remove(folder);
            _unitOfWork.Commit();
        }
    }
}
