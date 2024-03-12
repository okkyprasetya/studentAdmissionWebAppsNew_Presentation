using System;
using System.Collections.Generic;
using System.Text;

namespace studentAdmissionBO.ApplicantBO
{
    public class Applicant
    {
        public int UGDataID { get; set; }
        public int UserID { get; set; }
        public int UADataID { get; set; }
        public int UPDataID {  get; set; }
        public string NIS { get; set; }
        public string DateBirth { get; set; }
        public bool isScholarship { get; set; }
        public int ScholarshipID { get; set; }
        public int countVerif { get; set; }
        public bool isFinal { get; set; }
        public Scholarship scholarship { get; set; }
        public ApplicantPersonalData personalData { get; set; }
        public ApplicantAcademicData academicData { get; set; }
        public ApplicantAchievementRecord achievementRecord { get; set; }
    }
}
