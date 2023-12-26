using Microsoft.AspNetCore.Mvc;
using PashaBank.Services.Abstractions.Auth;
using PashaBank.Services.Models.RequestModels;
using PashaBank.Services.Models.ResponseModels;

namespace PashaBank.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequestModel request)
        {
            var result = await _authService.LoginUser(request);
            return Ok(result);
        }

    }
}
