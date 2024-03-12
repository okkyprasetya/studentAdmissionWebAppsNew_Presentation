using System;
using System.Collections.Generic;
using System.Text;

namespace studentAdmissionDTO.ApplicantDTO
{
    public class CreateApplicantDTO
    {
        public int UGDataID { get; set; }
        public string NIS { get; set; }
        public string DateBirth { get; set; }
        public bool isScholarship { get; set; }
        public int ScholarshipID { get; set; }
    }
}
