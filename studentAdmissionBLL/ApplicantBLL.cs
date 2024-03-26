using studentAdmissionBLL.BLLInterface;
using studentAdmissionBO;
using studentAdmissionBO.ApplicantBO;
using studentAdmissionDAL;
using studentAdmissionDAL.DALInterface;
using studentAdmissionDTO;
using studentAdmissionDTO.ApplicantDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentAdmissionBLL
{
    public class ApplicantBLL : BLLInterface.IApplicant
    {
        private readonly studentAdmissionDAL.DALInterface.IApplicant _applicantDAL;

        public ApplicantBLL()
        {
            _applicantDAL = new ApplicantDAL();
        }
        public void addAchievementRecord(CreateAchievementRecordDTO entity)
        {
            try
            {
                var AcademicData = new ApplicantAchievementRecord
                {
                    UGDataID = entity.UGDataID,
                    Title = entity.Title,
                    Level = entity.Level,
                    Description = entity.Description,
                    AchievementDocument = entity.AchievementDocument
                };
                _applicantDAL.addAchievementRecord(AcademicData);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void completeApplicantAcademicData(UpdateAcademicDataDTO entity)
        {
            try
            {
                var AcademicData = new ApplicantAcademicData
                {
                    UGDataID = entity.UGDataID,
                    RaportSummaries = entity.RaportSummaries,
                    RaportDocument = entity.RaportDocument
                };
                _applicantDAL.completeApplicantAcademicData(AcademicData);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void completeApplicantGeneralData(CreateApplicantDTO entity)
        {
            try
            {
                var AcademicData = new Applicant
                {
                    UGDataID = entity.UGDataID,
                    NIS = entity.NIS,
                    DateBirth = entity.DateBirth,
                    isScholarship = entity.isScholarship,
                    ScholarshipID = entity.ScholarshipID,
                };
                _applicantDAL.completeApplicantGeneralData(AcademicData);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void completeApplicantPersonalData(UpdatePersonalDataDTO entity)
        {
            try
            {
                var AcademicData = new ApplicantPersonalData
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
                    SiblingsNumber = entity.SiblingNumber,
                    Hobi = entity.Hobi,
                    KKDocument = entity.KKDocument,
                    BirthDocument = entity.BirthDocument
                };
                _applicantDAL.completeApplicantPersonalData(AcademicData);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void finalizeData(int uid)
        {
            try
            {
                
                _applicantDAL.finalizeData(uid);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public String login(string email, string password)
        {
            string status = string.Empty;
            status = _applicantDAL.login(email, password);

            return status;
        }

        public void logOut()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UsersDTO> getAll()
        {
            List<UsersDTO> listApplicantDTO = new List<UsersDTO>();
            var applicants = _applicantDAL.getAll();
            foreach (var applicant in applicants)
            {
                listApplicantDTO.Add(new UsersDTO
                {
                    UserID = applicant.UserID,
                    UserEmail = applicant.UserEmail,
                    Password = applicant.Password,
                    FirstName = applicant.FirstName,
                    MiddleName = applicant.MiddleName,
                    LastName = applicant.LastName,
                });
            }
            return listApplicantDTO.AsQueryable();
        }

        public void register(UserCreateDTO entity)
        {
            try
            {
                var newApplicant = new Users
                {
                    UserEmail = entity.email,
                    Password = entity.password,
                    FirstName = entity.fname,
                    MiddleName = entity.midname,
                    LastName = entity.lname,
                };
                _applicantDAL.register(newApplicant);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public UsersDTO getUserByEmail(string email)
        {
            var user = _applicantDAL.getUserByEmail(email);

            if (user == null)
            {
                return null;
            }

            UsersDTO userDTO = new UsersDTO
            {
                UserID = user.UserID,
                UserEmail = user.UserEmail,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                RoleID = user.RoleID,
            };
            return userDTO;
        }

        public bool UpdateUserProfilePhoto(int userId, string photoPath)
        {
            return _applicantDAL.UpdateUserProfilePhoto(userId, photoPath);
        }

        public ApplicantsDTO getApplicantData(string email)
        {
            var user = _applicantDAL.getApplicantData(email);

            if (user == null)
            {
                return null;
            }

            ApplicantsDTO userDTO = new ApplicantsDTO
            {
                UserID= user.UserID,
                UGDataID = user.UGDataID,
                NIS = user.NIS,
                DateBirth = user.DateBirth,
                isScholarship = user.isScholarship,
                ScholarshipID = user.ScholarshipID,
                isFinal = user.isFinal,
            };
            return userDTO;
        }

        public AcademicDataDTO getAcademicData(string email)
        {
            var user = _applicantDAL.getAcademicData(email);
            if (user == null)
            {
                return null;
            }
            AcademicDataDTO academicDatas = new AcademicDataDTO
            {
                UADataID = user.UADataID,
                RaportDocument = user.RaportDocument,
                RaportSUmmaries = user.RaportSummaries,
                isVerified = user.isVerified,
            };
            return academicDatas;
        }

        public List<AchievementRecordDTO> getAchievementRecord(string email)
        {
            var records = _applicantDAL.getAchievementRecord(email);
            List<AchievementRecordDTO> achievementRecords = new List<AchievementRecordDTO>();
            foreach (var record in records)
            {
                AchievementRecordDTO achievementRecord = new AchievementRecordDTO
                {
                    AchievementID = record.AchievementID,
                    Title = record.Title,
                    Description = record.Description,
                    Level = record.Level,
                    AchievementDocument = record.AchievementDocument,
                    isVerified = record.isVerified
                };
                if (achievementRecord.AchievementID != 0)
                {
                    achievementRecords.Add(achievementRecord);
                }else
                {
                    return achievementRecords;
                }
            }

            return achievementRecords;


        }

        public PersonalDataDTO getPersonalData(string email)
        {
            var user = _applicantDAL.getPersonalData(email);
            if (user == null)
            {
                return null;
            }
            PersonalDataDTO academicDatas = new PersonalDataDTO
            {
                UPDataID = user.UPDataID,
                FatherName = user.FatherName,
                FatherAddress = user.FatherAddress,
                FatherJob = user.FatherJob,
                FatherSalary = user.FatherSalary,
                MotherName = user.MotherName,
                MotherAddress = user.MotherAddress,
                MotherJob = user.MotherJob,
                MotherSalary = user.MotherSalary,
                SiblingsNumber = user.SiblingsNumber,
                KKDocument = user.KKDocument,
                BirthDocument = user.BirthDocument,
                Hobi = user.Hobi,
                isVerified = user.isVerified,
            };
            return academicDatas;
        }

        public List<ScholarshipDTO> generateScholarship()
        {
            var scholarships = _applicantDAL.generateScholarship();
            if (scholarships == null)
            {
                return null;
            }

            List<ScholarshipDTO> scholarshipDTOs = new List<ScholarshipDTO>(); // Initialize list of DTOs

            foreach (var scholarship in scholarships)
            {
                ScholarshipDTO scholarshipDTO = new ScholarshipDTO
                {
                    ScholarshipID = scholarship.ScholarshipID,
                    Name = scholarship.Name,
                    Benefit = scholarship.Benefit,
                    Provider = scholarship.Provider
                };
                scholarshipDTOs.Add(scholarshipDTO); // Add each DTO to the list
            }

            return scholarshipDTOs; // Return the list of DTOs
        }

        public void updateApplicantPersonalData(UpdatePersonalDataDTO entity)
        {
            try
            {
                var PersonalData = new ApplicantPersonalData
                {
                    FatherName = entity.FatherName,
                    FatherAddress = entity.FatherAddress,
                    FatherJob = entity.FatherJob,
                    FatherSalary = entity.FatherSalary,
                    MotherName = entity.MotherName,
                    MotherAddress = entity.MotherAddress,
                    MotherJob = entity.MotherJob,
                    MotherSalary = entity.MotherSalary,
                    SiblingsNumber = entity.SiblingNumber,
                    Hobi = entity.Hobi,
                    KKDocument = entity.KKDocument,
                    BirthDocument = entity.BirthDocument,
                };
                _applicantDAL.updateApplicantPersonalData(PersonalData);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public void updateApplicantAcademicData(UpdateAcademicDataDTO entity)
        {
            try
            {
                var AcademicData = new ApplicantAcademicData
                { 
                    RaportSummaries = entity.RaportSummaries,
                    RaportDocument = entity.RaportDocument,
                };
                _applicantDAL.updateApplicantAcademicData(AcademicData);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public void deleteAchievementRecord(int achievementID)
        {
            try
            {
                _applicantDAL.deleteAchievementRecord(achievementID);
            }
            catch (Exception ex)
            {
                // Log the error or handle it as needed
                throw new Exception("Error while deleting achievement record: " + ex.Message);
            }
        }

        public async Task<string> loginAsync(string email, string password)
        {
            string status = string.Empty;
            status = _applicantDAL.login(email, password);
            return status;
        }

        public List<RankDTO> GetRank()
        {
            List<RankDTO> ranks = new List<RankDTO>();
            try
            {
                var Ranks = _applicantDAL.GetRank();
                foreach (var rank in Ranks)
                {
                    ranks.Add(new RankDTO
                    {
                        Rank = rank.Rank,
                        RegistrationID = rank.RegistrationID,
                        Name = rank.Name,
                        TotalScore = rank.TotalScore,
                        status = rank.status
                    });
                }
                return ranks;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error fetching data: " + ex.Message);
            }
        }
    }
}
