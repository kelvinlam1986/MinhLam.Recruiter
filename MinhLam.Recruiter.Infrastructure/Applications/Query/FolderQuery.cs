using MinhLam.Recruiter.Application.Query;
using MinhLam.Recruiter.Application.Query.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace MinhLam.Recruiter.Infrastructure.Applications.Query
{
    public class FolderQuery : IFolderQuery
    {
        private readonly JobContext jobContext;

        public FolderQuery(JobContext context)
        {
            this.jobContext = context;
        }

        public List<FolderDto> GetFolderList(Guid recruiterdId, string sortColumn = "", string sortType = "")
        {
            var sql = "SELECT F.Id as FolderId, F.FolderName, F.FolderDescription, " +
                                      "Count(P.FolderId) as Jobs, F.FolderManager " +
                              "FROM RCFolders F " +
                              "LEFT JOIN RCJobPostings P ON F.Id = P.FolderId " +
                              "WHERE F.RecruiterId = @RecruiterId " +
                              "GROUP BY F.Id, F.FolderName, F.FolderDescription, F.FolderManager " +
                              "ORDER BY COUNT(P.FolderId) DESC";
            var sqlParameter = new SqlParameter("@RecruiterId", recruiterdId);
            var folderList = jobContext.Database.SqlQuery<FolderDto>(sql, sqlParameter).ToList();
            switch (sortColumn)
            {
                case "FolderName":
                    if (sortType == "ASC")
                    {
                        folderList = folderList.OrderBy(x => x.FolderName).ToList();
                    }
                    else
                    {
                        folderList = folderList.OrderByDescending(x => x.FolderName).ToList();
                    }
                    break;
                case "Jobs":
                    if (sortType == "ASC")
                    {
                        folderList = folderList.OrderBy(x => x.Jobs).ToList();
                    }
                    else
                    {
                        folderList = folderList.OrderByDescending(x => x.Jobs).ToList();
                    }
                    break;
                default:
                    folderList = folderList.OrderBy(x => x.FolderName).ToList();
                    break;
            }

            return folderList;
        }
    }
}
