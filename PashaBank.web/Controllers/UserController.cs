using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PashaBank.Services.Abstractions;
using PashaBank.Services.Abstractions.Auth;
using PashaBank.Services.Models.RequestModels;
using PashaBank.Services.Models.ResponseModels;
using PashaBank.Services.Models.ResponseModels.User;
using System.Security.Claims;

namespace PashaBank.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _auth;
        public UserController(IUserService userService, IAuthService auth)
        {
            _userService = userService;
            _auth = auth;
        }

        [Authorize]
        [HttpPost("AddDistributor")]
        public async Task<ActionResult<AddUserResponse>> AddUser(UserDto entity, int? recommenderId)
        {
            var role = HttpContext.User.FindFirst(ClaimTypes.Role);
            if (role.Value == "Addministrator")
            {
                var result = await _auth.RegisterUserAsync(entity, recommenderId);
                return Ok(result);
            }
            return Unauthorized(new AddUserResponse
            {
                Message = "თქვენ არ გაქვთ უფლება ამ მოქმედების შესასრულებლად",
                StatusCode = StatusCodes.Status401Unauthorized,
            });

        }
        [Authorize]
        [HttpPut("EditDistributorInfo")]
        public async Task<ActionResult<EditUserResponse>> EditUser(UserDto entity, int? recommenderId)
        {
            var role = HttpContext.User.FindFirst(ClaimTypes.Role);
            if (role.Value == "Distributtor")
            {
                var result = await _userService.EditUserInfo(entity, recommenderId);
                return Ok(result);
            }
            return Unauthorized(new EditUserResponse
            {
                Message = "თქვენ არ გაქვთ უფლება ამ მოქმედების შესასრულებლად",
                StatusCode = StatusCodes.Status401Unauthorized,
            });
        }

        [Authorize]
        [HttpDelete("RemoveDistributor")]
        public async Task<ActionResult<RemoveUserResponse>> RemoveUser(int distributorId)
        {
            var role = HttpContext.User.FindFirst(ClaimTypes.Role);
            if (role.Value == "Addministrator")
            {
                var result = await _userService.RemoveUser(distributorId);
                return Ok(result);
            }
            return Unauthorized(new RemoveUserResponse
            {
                Message = "თქვენ არ გაქვთ უფლება ამ მოქმედების შესასრულებლად",
                StatusCode = StatusCodes.Status401Unauthorized,
            });
        }
        [Authorize]
        [HttpGet("GetDistributorList")]
        public async Task<GetUsersResponse> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }
        [Authorize]
        [HttpGet("GetRecommendators")]
        public async Task<GetUsersResponse> GetRecommendatorList()
        {
            var role = HttpContext.User.FindFirst(ClaimTypes.Role);
            if (role.Value == "Addministrator")
            {
                return await _userService.GetRecommendatorList();
            }
            return new GetUsersResponse
            {
                Message = "თქვენ არ გაქვთ უფლება ამ მოქმედების შესასრულებლად",
                StatusCode = StatusCodes.Status401Unauthorized,
                Users = null
            };
        }
    }
}
