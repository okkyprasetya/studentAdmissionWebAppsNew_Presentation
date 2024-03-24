using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentAdmissionBLL.BLLInterface;
using studentAdmissionDTO;
using studentAdmissionDTO.ApplicantDTO;
using System.Linq.Expressions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicant _applicant;
        public ApplicantController(IApplicant applicant)
        {
            _applicant = applicant;
        }

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
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<String>> Login(string email, string password)
        {
            try
            {
                var result = _applicant.login(email, password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("completeApplicantAcademicData")]
        public async Task<ActionResult> completeApplicantAcademicData(UpdateAcademicDataDTO entity)
        {
            try
            {
                _applicant.completeApplicantAcademicData(entity);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("completeApplicantGeneralData")]
        public async Task<ActionResult> completeApplicantGeneralData(CreateApplicantDTO entity)
        {
            try
            {
                _applicant.completeApplicantGeneralData(entity);
                return Ok();
            }
            catch( Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("completeApplicantPersonalData")]
        public async Task<ActionResult> completeApplicantPersonalData(UpdatePersonalDataDTO entity)
        {
            try
            {
                _applicant.completeApplicantPersonalData(entity);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("finalizeMyData")]
        public async Task<ActionResult> finalizeMyData(int uid)
        {
            try
            {
                _applicant.finalizeData(uid);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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

        [HttpPut("updateApplicantPersonalData")]
        public async Task<ActionResult> updateApplicantPersonalData(UpdatePersonalDataDTO entity)
        {
            try
            {
                _applicant.updateApplicantPersonalData(entity);
                return Ok();
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [HttpPut("updateApplicantAcademicData")]
        public async Task<ActionResult> updateApplicantAcademicData(UpdateAcademicDataDTO entity)
        {
            try
            {
                _applicant.updateApplicantAcademicData(entity);
                return Ok();
            }
            catch(Exception exception)
            {
                 throw new ArgumentException(exception.Message);
            }
        }

        [HttpDelete("deleteAchievementRecords")]
        public async Task<ActionResult> deleteAchievementRecord(int achivementID)
        {
            try
            {
                _applicant.deleteAchievementRecord(achivementID);
                return Ok();
            }
            catch(Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
        
    }
}
