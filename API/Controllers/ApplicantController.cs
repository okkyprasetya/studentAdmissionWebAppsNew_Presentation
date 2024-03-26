using API.Helper;
using API.Viewmodel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using studentAdmissionBLL.BLLInterface;
using studentAdmissionDTO;
using studentAdmissionDTO.ApplicantDTO;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicant _applicant;
        private readonly AppSetting _appSetting;
        public ApplicantController(IApplicant applicant,IOptions<AppSetting> appSetting)
        {
            _applicant = applicant;
            _appSetting = appSetting.Value;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicantsDTO>>> Get(string email)
        {
            try
            {
                var applicants = _applicant.getUserByEmail(email);
                return Ok(applicants);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserCreateDTO entity)
        {
            try
            {
                _applicant.register(entity);
                return Ok("Register success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(string email, string password)
        {
            //try
            //{
            //    var result = _applicant.login(email, password);
            //    return Ok(result);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            var result = await _applicant.loginAsync(email, password);
            if (result == "Login successful")
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, result));

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var userWithToken = new UserToken
                {
                    token = tokenHandler.WriteToken(token)
                };
                return Ok(userWithToken);
            }
            else
            {
                return BadRequest("invalid credentials");
            }
        }

        [Authorize]
        [HttpPost("completeApplicantAcademicData")]
        public async Task<ActionResult> completeApplicantAcademicData(UpdateAcademicDataDTO entity)
        {
            try
            {
                _applicant.completeApplicantAcademicData(entity);
                return Ok("Data has been updated");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("completeApplicantGeneralData")]
        public async Task<ActionResult> completeApplicantGeneralData(CreateApplicantDTO entity)
        {
            try
            {
                _applicant.completeApplicantGeneralData(entity);
                return Ok("Data has been updated");
            }
            catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("completeApplicantPersonalData")]
        public async Task<ActionResult> completeApplicantPersonalData(UpdatePersonalDataDTO entity)
        {
            try
            {
                _applicant.completeApplicantPersonalData(entity);
                return Ok("Data has been updated");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("finalizeMyData")]
        public async Task<ActionResult> finalizeMyData(int uid)
        {
            try
            {
                _applicant.finalizeData(uid);
                return Ok("Data has been finalized");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("addAchievementRecord")]
        public async Task<ActionResult> addnewAchievement(CreateAchievementRecordDTO entity)
        {
            try
            {
                _applicant.addAchievementRecord(entity);
                return Ok("Achievement added");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getRank")]
        public async Task<List<RankDTO>> getRank()
        {
            try
            {
                var results = _applicant.GetRank();
                return results.ToList();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Authorize]
        [HttpGet("getApplicantData")]
        public async Task<ApplicantsDTO> getApplicantData(string email)
        {
            try
            {
                var result = _applicant.getApplicantData(email);
                return result;
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("getAcademicData")]
        public async Task<AcademicDataDTO> getAcademicData(string email)
        {
            try
            {
                var result = _applicant.getAcademicData(email);
                return result;
            }
            catch(Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        [Authorize]
        [HttpGet("getAchievementRecord")]
        public async Task<List<AchievementRecordDTO>> getAchievementRecord(string email)
        {
            try
            {
                var results = _applicant.getAchievementRecord(email);
                return results;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("getPersonalData")]
        public async Task<PersonalDataDTO> getPersonalData(string email)
        {
            try
            {
                var result = _applicant.getPersonalData(email);
                return result;
            }
            catch(Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        [Authorize]
        [HttpGet("getScholarshipData")]
        public async Task<List<ScholarshipDTO>> getScholarshipData()
        {
            try
            {
                var results = _applicant.generateScholarship();
                return results;
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("updateApplicantPersonalData")]
        public async Task<ActionResult> updateApplicantPersonalData(UpdatePersonalDataDTO entity)
        {
            try
            {
                _applicant.updateApplicantPersonalData(entity);
                return Ok("Data has been updated");
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("updateApplicantAcademicData")]
        public async Task<ActionResult> updateApplicantAcademicData(UpdateAcademicDataDTO entity)
        {
            try
            {
                _applicant.updateApplicantAcademicData(entity);
                return Ok("Data has been updated");
            }
            catch(Exception exception)
            {
                 throw new ArgumentException(exception.Message);
            }
        }

        [Authorize]
        [HttpDelete("deleteAchievementRecords")]
        public async Task<ActionResult> deleteAchievementRecord(int achivementID)
        {
            try
            {
                _applicant.deleteAchievementRecord(achivementID);
                return Ok("Data has been deleted");
            }
            catch(Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
        
    }
}
