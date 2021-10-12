using MinhLam.Framework;
using System;

namespace MinhLam.Recruiter.Domain
{
    public class RCSavedSearch : AggregateRoot
    {
        public Guid RecruiterId { get; protected set; }
        public string Keyword { get; protected set; }
        public Guid JobCategoryId { get; protected set; }
        public Guid JobIndustryId { get; protected set; }
        public Guid CertificateId { get; protected set; }
        public Guid ProvinceId { get; protected set; }
        public Guid WorkingLevelId { get; protected set; }
        public Guid WorkingTypeId { get; protected set; }
        public int Gender { get; protected set; }
        public int Availability { get; protected set; }
        public int MinAge { get; protected set; }
        public int MaxAge { get; protected set; }
        public DateTime SaveDate { get; protected set; }

        public static RCSavedSearch New(
            Guid recruiterId,
            string keyword,
            Guid categoryId,
            Guid industryId,
            Guid certificateId,
            Guid provinceId,
            Guid workingLevelId,
            Guid workingTypeId,
            int gender,
            int availability,
            int minAge,
            int maxAge,
            IRCSavedSearchRepository savedSearchRepository,
            ICheckExisting checkExisting)
        {
            var savedSearchList = savedSearchRepository.GetListByRecruiterId(recruiterId);
            var countSavedSearch = savedSearchList.Count;
            bool isExist = checkExisting.RCSavedSearchExistWith(
                recruiterId,
                keyword,
                certificateId,
                categoryId,
                industryId,
                provinceId,
                workingTypeId,
                workingLevelId,
                gender,
                availability,
                minAge,
                maxAge);

            if (countSavedSearch < 10 && isExist == false)
            {
                var saveDate = DateTime.Now;
                return new RCSavedSearch(
                    Guid.NewGuid(),
                    recruiterId,
                    keyword,
                    categoryId,
                    industryId,
                    certificateId,
                    provinceId,
                    workingLevelId,
                    workingTypeId,
                    gender,
                    availability,
                    minAge,
                    maxAge,
                    saveDate
                    );
            }

            return null;
        }

        protected RCSavedSearch(
            Guid id,
            Guid recruiterId,
            string keyword,
            Guid jobCategoryId,
            Guid jobIndustryId,
            Guid certificateId,
            Guid provinceId,
            Guid workingLevelId,
            Guid workingTypeId,
            int gender,
            int availability,
            int minAge,
            int maxAge,
            DateTime saveDate
            )
        {
            Id = id;
            RecruiterId = recruiterId;
            Keyword = keyword;
            JobCategoryId = jobCategoryId;
            JobIndustryId = jobIndustryId;
            CertificateId = certificateId;
            ProvinceId = provinceId;
            WorkingLevelId = workingLevelId;
            WorkingTypeId = workingTypeId;
            Gender = gender;
            Availability = availability;
            MinAge = minAge;
            MaxAge = maxAge;
            SaveDate = saveDate;
        }
    }
}
