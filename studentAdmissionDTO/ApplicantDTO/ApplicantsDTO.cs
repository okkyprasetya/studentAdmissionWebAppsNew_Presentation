using System;
using System.Collections.Generic;
using System.Text;

namespace studentAdmissionDTO.ApplicantDTO
{
    public class ApplicantsDTO
    {
        public int UGDataID { get; set; }
        public int UserID { get; set; }
        public int UADataID { get; set; }
        public int UPDataID { get; set; }
        public string NIS { get; set; }
        public string DateBirth { get; set; }
        public bool isScholarship { get; set; }
        public int ScholarshipID { get; set; }
        public int countVerif { get; set; }
        public bool isFinal { get; set; }
        public string token { get; set; }
        public ScholarshipDTO scholarship { get; set; }
        public PersonalDataDTO personalData { get; set; }
        public AcademicDataDTO academicData { get; set; }
        public AchievementRecordDTO achievementRecord { get; set; }
    }
}
