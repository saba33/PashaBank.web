using PashaBank.Services.Models.RequestModels;
using PashaBank.Services.Models.ResponseModels;
using PashaBank.Services.Models.ResponseModels.User;

namespace PashaBank.Services.Abstractions.Auth
{
    public interface IAuthService
    {
        Task<AddUserResponse> RegisterUserAsync(UserDto request, int? recommenderId);
        Task<LoginResponse> LoginUser(LoginRequestModel request);
        Task<Dictionary<byte[], byte[]>> GetHashandSalt(string mail);
    }
}
