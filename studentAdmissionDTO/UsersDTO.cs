using System;

namespace studentAdmissionDTO
{
    public class UsersDTO
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
