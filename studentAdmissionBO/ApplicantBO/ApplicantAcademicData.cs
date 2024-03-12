using System;
using System.Collections.Generic;
using System.Text;

namespace studentAdmissionBO.ApplicantBO
{
    public class ApplicantAcademicData
    {
        public int UADataID { get; set; }
        public int UGDataID { get; set; }
        public int RaportSummaries { get; set; }
        public string RaportDocument { get; set; }
        public bool isVerified { get; set; }

        public Applicant Applicant { get; set; }
    }
}
