using studentAdmissionDTO;
using studentAdmissionDTO.ApplicantDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace studentAdmissionBLL.BLLInterface
{
    public interface IUsers
    {
        String login(string email, string password);
        void register(UserCreateDTO entity);
        void logOut();

        UsersDTO getUserByEmail(String email);

        IQueryable<UsersDTO> getAll();
    }
}
