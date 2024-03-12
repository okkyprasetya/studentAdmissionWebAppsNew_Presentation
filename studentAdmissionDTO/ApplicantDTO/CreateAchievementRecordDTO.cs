using System;
using System.Collections.Generic;
using System.Text;

namespace studentAdmissionDTO.ApplicantDTO
{
    public class CreateAchievementRecordDTO
    {
        public int UGDataID { get; set; }
        public string Title { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public string AchievementDocument { get; set; }
    }
}
