using studentAdmissionBO.ApplicantBO;
using System;
using System.Collections.Generic;
using System.Text;

namespace studentAdmissionDAL.DALInterface
{
    public interface IVerificator
    {
        Applicant getApplicantByID(int id);
        void completeVerificatorData(int verificatorID, string position, string SKNumber);
        void verifyAcademicData(int verificatorID, int UGDataID);
        void verifyAchievementRecord(int verificatorID, int UGDataID);
        void verifyPersonalData(int verificatorID,int UGDataID);
        void finalizeLeaderboard();
        void AssignBills();
    }
}
