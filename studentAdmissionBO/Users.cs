using System;
using System.Collections.Generic;
using System.Text;

namespace studentAdmissionBO
{
    public class Users
    {
        public int UserID { get; set; }
        public String UserEmail { get; set; }
        public String Password { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String CreatedAt { get; set; }
        public String UpdatedAt { get; set; }
        public int RoleID { get; set; }
    }
}
