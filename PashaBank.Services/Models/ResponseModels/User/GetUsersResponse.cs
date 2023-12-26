using PashaBank.Services.Models.RequestModels;

namespace PashaBank.Services.Models.ResponseModels.User
{
    public class GetUsersResponse : BaseResponse
    {
        public IEnumerable<UserDto> Users { get; set; }
    }
}
