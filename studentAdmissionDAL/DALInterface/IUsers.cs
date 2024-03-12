using studentAdmissionBO;
using studentAdmissionBO.ApplicantBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace studentAdmissionDAL.DALInterface
{
    public interface IUsers
    {
        String login(string email, string password);
        void register(Users entity);
        void logOut();

        Users getUserByEmail(String email);
        IEnumerable<Users> getAll();
    }
}
