using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TtryJWTToken.Data;
using TtryJWTToken.Services;

namespace TtryJWTToken.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authservice;
        public AuthController(IAuthService authservice)
        {
            _authservice = authservice;
        }

        [HttpPost("register")]
        public async Task<IActionResult> registerAsync(RegisterModel model)
        {
            //Check Validity
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authservice.RegisterAsync(model);
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPost("token")]
        public async Task<IActionResult> Gettokenasync(TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authservice.GetTokenAsync(model);
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync(AddRoleModel input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authservice.AddRoleAsync(input);
            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);
            return Ok(input);
        }

    }
}