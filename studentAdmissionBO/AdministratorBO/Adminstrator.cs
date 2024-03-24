using System;
using System.Collections.Generic;
using System.Text;

namespace studentAdmissionBO.AdministratorBO
{
    public class Adminstrator:Users
    {
        public int AdminID { get; set; }
        public Role Role { get; set; }
    }
}
