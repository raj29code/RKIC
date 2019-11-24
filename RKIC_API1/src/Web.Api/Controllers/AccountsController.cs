using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Model;
using Service.Users.Interface;
using Web.Api.Core.Dto.UseCaseRequests;
using Web.Api.Core.Interfaces.UseCases;
using Web.Api.Presenters;


namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _registerUserUseCase;

        public AccountsController(IUserService registerUserUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
 
        }

        // POST api/accounts
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Request.RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user =new User {
                FirstName = request.FirstName,
                LastName= request.LastName,
                Email = request.Email,
                UserName = request.UserName,
                Password =  request.Password };
               var result = await _registerUserUseCase.createUser(user);
            return Ok(result);
        }
    }
}
