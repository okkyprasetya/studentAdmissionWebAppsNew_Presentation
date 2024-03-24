using Dapper;
using studentAdmissionBO;
using studentAdmissionBO.ApplicantBO;
using studentAdmissionDAL.DALInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace studentAdmissionDAL
{
    public class ApplicantDAL : IApplicant,IUsers
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
        }
        public void addAchievementRecord(ApplicantAchievementRecord entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var procedure = "dbo.addAchievement";
                var parameter = new
                {
                    Title = entity.Title,
                    Level = entity.Level,
                    Description = entity.Description,
                    Document = entity.AchievementDocument,
                    UGDataID = entity.UGDataID,
                };
                try
                {
                    int result = conn.Execute(procedure, parameter, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Failed to add new achievement record");
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public void completeApplicantAcademicData(ApplicantAcademicData entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var procedure = "dbo.completeAcademicData";
                var parameter = new
                {
                    UGDataID = entity.UGDataID,
                    RaportSummaries = entity.RaportSummaries,
                    RaportDocument = entity.RaportDocument
                };
                try
                {
                    int result = conn.Execute(procedure, parameter, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Update academic data Failed");
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public void completeApplicantGeneralData(Applicant entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var procedure = "dbo.completeApplicantData";
                var parameter = new
                {
                    UGDataID = entity.UGDataID,
                    nis = entity.NIS,
                    datebirth = entity.DateBirth,
                    isScholarship = entity.isScholarship,
                    scholarshipID = entity.ScholarshipID
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

        public void completeApplicantPersonalData(ApplicantPersonalData entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var procedure = "dbo.completePersonalData";
                var parameter = new
                {
                    UGDataID = entity.UGDataID,
                    FatherName = entity.FatherName,
                    FatherAddress = entity.FatherAddress,
                    FatherJob = entity.FatherJob,
                    FatherSalary = entity.FatherSalary,
                    MotherName = entity.MotherName,
                    MotherAddress = entity.MotherAddress,
                    MotherJob = entity.MotherJob,
                    MotherSalary = entity.MotherSalary,
                    SiblingsNumber = entity.SiblingsNumber,
                    Hobi = entity.Hobi,
                    KKDocument = entity.KKDocument,
                    BirthDocument = entity.BirthDocument
                };
                try
                {
                    int result = conn.Execute(procedure, parameter, commandType: System.Data.CommandType.StoredProcedure);
                    if (result != 1)
                    {
                        throw new ArgumentException("Register Failed");
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public void finalizeData(int uid)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("dbo.finalizeApplicantData", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", uid);

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                }
            }
        }

        public String login(string email,string password)
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

        public IEnumerable<Users> getAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString())) {
                var strSql = "SELECT * FROM UserData WHERE RoleID=2";
                try
                {
                    var result = conn.Query<Users>(strSql, commandType: System.Data.CommandType.Text);
                    return result;
                }
                catch(Exception ex){
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public void register(Users entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var procedure = "Insert into dbo.UserData (UserEmail,Password,FirstName,MiddleName,LastName,CreatedAt,UpdatedAt,RoleID) VALUES (@email,@password,@fname,@midname,@lname,@CreatedAt,@UpdatedAt,2)";
                var procedure1 = "dbo.addApplicant";

                var parameter = new
                {
                    email = entity.UserEmail,
                    password = entity.Password,
                    fname = entity.FirstName,
                    midname = entity.MiddleName,
                    lname = entity.LastName,
                    //CreatedAt = DateTime.Now,
                    //UpdatedAt = DateTime.Now
                };
                try
                {
                    int result = conn.Execute(procedure1, parameter, commandType: System.Data.CommandType.StoredProcedure);
                    if(result == 0)
                    {
                        throw new ArgumentException("Failed Insert");
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public Users getUserByEmail(string email)
        {
            Users user = null;
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                string query = "SELECT * FROM UserData WHERE UserEmail = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new Users
                            {
                                UserID = (int)reader["UserId"],
                                UserEmail = reader["UserEmail"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                MiddleName = reader["MiddleName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                RoleID = (int)reader["RoleID"]
                            };
                        }
                    }
                }
            }

            return user;
        }

        public bool UpdateUserProfilePhoto(int userId, string photoPath)
        {
            try
            {
                byte[] photoData = File.ReadAllBytes(photoPath);

                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "UPDATE UserData SET profilePhoto = @PhotoData WHERE UserID = @UserId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PhotoData", photoData);
                    command.Parameters.AddWithValue("@UserId", userId);
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating user profile photo: " + ex.Message);
                return false;
            }
        }

        public Applicant getApplicantData(string email)
        {
            Applicant applicantGeneralData = null;
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                string query = "SELECT * FROM dbo.UserData AS A LEFT JOIN dbo.ApplicantData AS B ON A.UserID = B.UserID WHERE a.UserEmail = @email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            applicantGeneralData = new Applicant
                            {
                                UserID = reader["UserID"] == DBNull.Value ? 0 : (int)reader["UserID"],
                                NIS = reader["NIS"] == DBNull.Value ? null: reader["NIS"].ToString(),
                                UGDataID = (int)reader["UGDataID"],
                                isScholarship = reader["isScholarship"] == DBNull.Value ? false : (bool)reader["isScholarship"],
                                ScholarshipID = reader["ScholarshipID"] == DBNull.Value? 0 : (int)reader["ScholarshipID"],
                                countVerif = reader["countVerif"] == DBNull.Value? 0 : (int)reader["countVerif"],
                                isFinal = reader["isFinal"] == DBNull.Value? false : (bool)reader["isFinal"],
                                UADataID = reader["UADataID"] == DBNull.Value? 0 : (int)reader["UADataID"],
                                UPDataID = reader["UPDataID"] == DBNull.Value ? 0 : (int)reader["UPDataID"],
                                DateBirth = reader["DateBirth"] == DBNull.Value ? null : reader["DateBirth"].ToString()
                            };
                        }
                    }
                }
            }

            return applicantGeneralData;
        }

        public ApplicantAcademicData getAcademicData(string email)
        {
            ApplicantAcademicData applicantAcademicData = null;
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                string query = "SELECT * FROM dbo.UserData AS A LEFT JOIN dbo.ApplicantData AS B ON A.UserID = B.UserID LEFT JOIN dbo.ApplicantAcademicData AS C ON B.UADataID = C.UADataID WHERE a.UserEmail = @email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            applicantAcademicData = new ApplicantAcademicData
                            {
                                UADataID = reader["UADataID"] == DBNull.Value ? 0: (int)reader["UADataID"],
                                RaportDocument = reader["RaportDocument"] == DBNull.Value ? "" : reader["RaportDocument"].ToString(),
                                RaportSummaries = reader["RaportSummaries"] == DBNull.Value ? 0 : (int)reader["RaportSummaries"],
                                isVerified = reader["isVerified"] == DBNull.Value ? false : (bool)reader["isVerified"]
                            };
                        }
                    }
                }
            }

            return applicantAcademicData;
        }

        public List<ApplicantAchievementRecord> getAchievementRecord(string email)
        {
            List<ApplicantAchievementRecord> achievementRecords = new List<ApplicantAchievementRecord>();

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                string query = "SELECT * FROM dbo.UserData AS A LEFT JOIN dbo.ApplicantData AS B ON A.UserID = B.UserID LEFT JOIN dbo.ApplicantAchievementRecord AS C ON B.UGDataID = C.UGDataID WHERE a.UserEmail = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ApplicantAchievementRecord applicantAchievementData = new ApplicantAchievementRecord
                            {
                                AchievementID = reader["AchievementID"] == DBNull.Value ? 0 : (int)reader["AchievementID"],
                                Title = reader["Title"] == DBNull.Value ? "" : reader["Title"].ToString(),
                                Level = reader["Level"] == DBNull.Value ? "" : reader["Level"].ToString(),
                                Description = reader["Description"] == DBNull.Value ? "" : reader["Description"].ToString(),
                                isVerified = reader["isVerified"] == DBNull.Value ? false : (bool)reader["isVerified"]
                            };

                            achievementRecords.Add(applicantAchievementData);
                        }
                    }
                }
            }

            return achievementRecords;
        }

        public ApplicantPersonalData getPersonalData(string email)
        {
            ApplicantPersonalData applicantPersonalData = null;
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                string query = "SELECT * FROM dbo.UserData AS A LEFT JOIN dbo.ApplicantData AS B ON A.UserID = B.UserID LEFT JOIN dbo.ApplicantPersonalData AS C ON B.UPDataID = C.UPDataID WHERE a.UserEmail = @email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            applicantPersonalData = new ApplicantPersonalData
                            {
                                UPDataID = reader["UPDataID"] == DBNull.Value? 0: (int)reader["UPDataID"],
                                FatherName = reader["FatherName"] == DBNull.Value ? "": reader["FatherName"].ToString(),
                                FatherAddress = reader["FatherAddress"] == DBNull.Value ? "": reader["FatherAddress"].ToString(),
                                FatherJob = reader["FatherJob"] == DBNull.Value ? "": reader["FatherJob"].ToString(),
                                FatherSalary = reader["FatherSalary"] == DBNull.Value ? 0: (int)reader["FatherSalary"],
                                MotherName = reader["MotherName"] == DBNull.Value? "": reader["MotherName"].ToString(),
                                MotherAddress = reader["MotherAddress"] == DBNull.Value? "": reader["MotherAddress"].ToString(),
                                MotherJob = reader["MotherJob"] == DBNull.Value? "": reader["MotherJob"].ToString(),
                                MotherSalary = reader["MotherSalary"] == DBNull.Value? 0: (int)reader["MotherSalary"],
                                SiblingsNumber = reader["SiblingsNumber"] == DBNull.Value? 0: (int)reader["SiblingsNumber"],
                                Hobi = reader["Hobi"] == DBNull.Value? "": reader["Hobi"].ToString(),
                                KKDocument = reader["KKDocument"] == DBNull.Value? "" : reader["KKDocument"].ToString(),
                                BirthDocument = reader["BirthDocument"] == DBNull.Value? "": reader["BirthDocument"].ToString(),

                                isVerified = reader["isVerified"] == DBNull.Value ? false : (bool)reader["isVerified"]
                            };
                        }
                    }
                }
            }

            return applicantPersonalData;
        }

        public List<Scholarship> generateScholarship()
        {
            List<Scholarship> scholarships = new List<Scholarship>(); // Initialize list
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                string query = "SELECT * FROM dbo.ScholarshipData";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) // Use while loop to iterate through all rows
                        {
                            Scholarship scholarship = new Scholarship
                            {
                                ScholarshipID = (int)reader["ScholarshipID"],
                                Name = (string)reader["Name"],
                                Benefit = (string)reader["Benefit"],
                                Provider = (string)reader["Provider"]
                            };
                            scholarships.Add(scholarship); // Add each scholarship to the list
                        }
                    }
                }
            }

            return scholarships;
        }

        public void updateApplicantPersonalData(ApplicantPersonalData entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "UPDATE ApplicantPersonalData SET FatherName = @FN,FatherAddress = @FA, FatherJob= @FJ, FatherSalary = @FS, MotherName= @MN, MotherAddress = @MA, MotherJob = @MJ, MotherSalary = @MS, SiblingsNumber =@SN, Hobi = @HB, KKDocument = @KD, BirthDocument =@BD WHERE UPDataID = @Updi";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FN", entity.FatherName);
                    command.Parameters.AddWithValue("@FA", entity.FatherAddress);
                    command.Parameters.AddWithValue("@FJ", entity.FatherJob);
                    command.Parameters.AddWithValue("@FS", entity.FatherSalary);
                    command.Parameters.AddWithValue("@MN", entity.MotherName);
                    command.Parameters.AddWithValue("@MA", entity.MotherAddress);
                    command.Parameters.AddWithValue("@MJ", entity.MotherJob);
                    command.Parameters.AddWithValue("@MS", entity.MotherSalary);
                    command.Parameters.AddWithValue("@SN", entity.SiblingsNumber);
                    command.Parameters.AddWithValue("@HB", entity.Hobi);
                    command.Parameters.AddWithValue("@KD", entity.KKDocument);
                    command.Parameters.AddWithValue("@BD", entity.BirthDocument);
                    command.Parameters.AddWithValue("@Updi", entity.UPDataID);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating user academic data: " + ex.Message);
            }
        }

        public void updateApplicantAcademicData(ApplicantAcademicData entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "UPDATE ApplicantAcademicData SET RaportSummaries = @rs,RaportDocument = @rd WHERE UADataID = @Uadi";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@rs", entity.RaportSummaries);
                    command.Parameters.AddWithValue("@rd", entity.RaportDocument);
                    command.Parameters.AddWithValue("@Uadi", entity.UADataID);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating user academic data: " + ex.Message);
            }
        }

        public void deleteAchievementRecord(int achievementID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "DELETE FROM dbo.ApplicantAchievementRecord WHERE AchievementID = @AchievementID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AchievementID", achievementID);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("Failed to delete achievement record");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting achievement record: " + ex.Message);
            }
        }
    }
}
