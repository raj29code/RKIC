using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Model.Student;
using Service.Registration.Interface;
using System.Threading.Tasks;

namespace Web.Api.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistartionController : ControllerBase
    {
        private readonly IStudentRegistration _registerStudent;

        public RegistartionController(IStudentRegistration registerStudent)
        {
            _registerStudent = registerStudent;

        }
        [HttpPost]
        [Route("StudentRegistration")]
        public async Task<IActionResult> StudentRegistration([FromBody] StudentRegistration studentRegistration)
        {
            var result = await _registerStudent.StudentRegistration(studentRegistration);
            return Ok(result);
        }
    }
}
