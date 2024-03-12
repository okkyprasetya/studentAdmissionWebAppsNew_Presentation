using studentAdmissionBO;
using studentAdmissionBO.ApplicantBO;
using studentAdmissionDTO;
using studentAdmissionDTO.ApplicantDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace studentAdmissionBLL.BLLInterface
{
    public interface IApplicant:IUsers
    {
        void finalizeData(int uid);
        void completeApplicantGeneralData(CreateApplicantDTO entity);
        void completeApplicantPersonalData(UpdatePersonalDataDTO entity);
        void updateApplicantPersonalData(UpdatePersonalDataDTO entity);
        void completeApplicantAcademicData(UpdateAcademicDataDTO entity);
        void updateApplicantAcademicData(UpdateAcademicDataDTO entity);
        void addAchievementRecord(CreateAchievementRecordDTO entity);
        void deleteAchievementRecord(int achievementID);
        bool UpdateUserProfilePhoto(int userId, string photoPath);
        List<ScholarshipDTO> generateScholarship();
        ApplicantsDTO getApplicantData(string email);
        AcademicDataDTO getAcademicData(string email);
        List<AchievementRecordDTO> getAchievementRecord(string email);
        PersonalDataDTO getPersonalData(string email);
    }
}
