using studentAdmissionBO;
using studentAdmissionDAL.DALInterface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using studentAdmissionBO.VerificatorBO;
using Dapper;
using studentAdmissionBO.ApplicantBO;

namespace studentAdmissionDAL
{
    public class VerificatorDAL : IVerificator, IUsers
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public void AssignBills()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("dbo.AssignBillsToStudents", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                }
            }
        }

        public void completeVerificatorData(int verificatorID, string position, string SKNumber)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var procedure = "dbo.completeApplicantData";
                var parameter = new
                {
                    verificatorID = verificatorID,
                    position= position,
                    SKNumber = SKNumber
                };
                try
                {
                    int result = conn.Execute(procedure, parameter, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Update data failed");
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public void finalizeLeaderboard()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("dbo.finalizeLeaderboard", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                }
            }
        }

        public IEnumerable<Users> getAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = "SELECT * FROM UserData WHERE RoleID=2";
                try
                {
                    var result = conn.Query<Users>(strSql, commandType: System.Data.CommandType.Text);
                    return result;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public Users getUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public string login(string email, string password)
        {
            string status = string.Empty;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("dbo.Login", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        status = reader["Status"].ToString();
                    }
                }
                return status;
            }
        }

        public void logOut()
        {
            throw new NotImplementedException();
        }

        public void register(Users entity)
        {
            throw new NotImplementedException();
        }

        public void verifyAcademicData(int verificatorID, int UGDataID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("dbo.verifyAcademicData", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UGDataID", UGDataID);
                    command.Parameters.AddWithValue("@verificatorID", verificatorID);

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                }
            }
        }

        public void verifyAchievementRecord(int verificatorID, int UGDataID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("dbo.verifyAchievementRecord", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UGDataID", UGDataID);
                    command.Parameters.AddWithValue("@verificatorID", verificatorID);

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                }
            }
        }

        public void verifyPersonalData(int verificatorID, int UGDataID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("dbo.verifyPersonalData", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UGDataID", UGDataID);
                    command.Parameters.AddWithValue("@verificatorID", verificatorID);

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                }
            }
        }

        public Applicant getApplicantByID(int id)
        {
            //Users user = null;
            //using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            //{
            //    connection.Open();

            //    string query = "SELECT * FROM UserData WHERE UserID = @UserID AND RoleID = 2";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@UserID", id);

            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            if (reader.Read())
            //            {
            //                user = new Applicant
            //                {
            //                    UserID = (int)reader["UserId"],
            //                    UserEmail = reader["UserEmail"].ToString(),
            //                    FirstName = reader["FirstName"].ToString(),
            //                    MiddleName = reader["MiddleName"].ToString(),
            //                    LastName = reader["LastName"].ToString(),
            //                    RoleID = (int)reader["RoleID"]
            //                };
            //            }
            //        }
            //    }
            //}

            //return user;
            Applicant dummy = new Applicant();
            return dummy;
        }
    }
}
