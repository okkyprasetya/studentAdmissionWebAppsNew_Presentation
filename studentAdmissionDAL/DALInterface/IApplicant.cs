using studentAdmissionBO;
using studentAdmissionBO.ApplicantBO;
using System;
using System.Collections.Generic;
using System.Text;

namespace studentAdmissionDAL.DALInterface
{
    public interface IApplicant : IUsers
    {
        void finalizeData(int uid);
        void completeApplicantGeneralData(Applicant entity);
        void completeApplicantPersonalData(ApplicantPersonalData entity);
        void updateApplicantPersonalData(ApplicantPersonalData entity);
        void completeApplicantAcademicData(ApplicantAcademicData entity);
        void updateApplicantAcademicData(ApplicantAcademicData entity);
        void addAchievementRecord(ApplicantAchievementRecord entity);
        void deleteAchievementRecord(int achievementID);
        bool UpdateUserProfilePhoto(int userId, string photoPath);
        List<Scholarship> generateScholarship();
        Applicant getApplicantData(string email);
        ApplicantAcademicData getAcademicData(string email);
        List<ApplicantAchievementRecord> getAchievementRecord(string email);
        ApplicantPersonalData getPersonalData(string email);
        List<RankBO> GetRank();

    }
}
