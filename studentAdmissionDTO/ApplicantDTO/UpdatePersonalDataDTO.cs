using System;
using System.Collections.Generic;
using System.Text;

namespace studentAdmissionDTO.ApplicantDTO
{
    public class UpdatePersonalDataDTO
    {
        public int UGDataID { get; set; }

        public int UPDataID { get; set; }
        public String FatherName { get; set; }
        public String FatherAddress { get; set; }
        public String FatherJob { get; set; }
        public int FatherSalary { get; set; }
        public String MotherName { get; set; }
        public String MotherAddress { get; set; }
        public String MotherJob { get; set; }
        public int MotherSalary { get; set; }
        public int SiblingNumber { get; set; }
        public String Hobi { get; set; }
        public String KKDocument { get; set; }
        public String BirthDocument { get; set; }
    }
}
