using System;
using System.Collections.Generic;
using System.Text;

namespace studentAdmissionBO.VerificatorBO
{
    public class Verificator:Users
    {
        public int VerificatorID { get; set; }
        public string Position { get; set; }
        public string SKNumber { get; set; }
        public Role Role { get; set; }
    }
}
