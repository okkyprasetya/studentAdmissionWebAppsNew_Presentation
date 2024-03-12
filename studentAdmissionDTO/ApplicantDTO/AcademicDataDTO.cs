using System;
using System.Collections.Generic;
using System.Text;

namespace studentAdmissionDTO.ApplicantDTO
{
    public class AcademicDataDTO
    {
        public int UADataID { get; set; }
        public int UAGDataID { get; set; }
        public int RaportSUmmaries {  get; set; }
        public String RaportDocument {  get; set; } 
        public bool isVerified { get; set; }

        public ApplicantsDTO Applicant { get; set; }
    }
}
