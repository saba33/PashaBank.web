using PashaBank.Services.Models.RequestModels;
using PashaBank.Services.Models.ResponseModels;
using PashaBank.Services.Models.ResponseModels.User;

namespace PashaBank.Services.Abstractions
{
    public interface IUserService
    {
        //Task<AddUserResponse> AddUserAsync(UserDto user, int? recommenderId);
        Task<EditUserResponse> EditUserInfo(UserDto entity, int? recommenderId);
        Task<RemoveUserResponse> RemoveUser(int Id);
        Task<GetUsersResponse> GetAllUsers();
        Task<GetUsersResponse> GetRecommendatorList();
    }
}
