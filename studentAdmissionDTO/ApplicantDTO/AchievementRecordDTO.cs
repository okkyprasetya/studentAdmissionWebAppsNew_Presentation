using System;
using System.Collections.Generic;
using System.Text;

namespace studentAdmissionDTO.ApplicantDTO
{
    public class AchievementRecordDTO
    {
        public int AchievementID { get; set; }
        public int UGDataID { get; set; }
        public string Title { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public string AchievementDocument { get; set; }
        public int AchievementScore { get; set; }
        public bool isVerified { get; set; }
        public ApplicantsDTO Applicant { get; set; }
    }
}
