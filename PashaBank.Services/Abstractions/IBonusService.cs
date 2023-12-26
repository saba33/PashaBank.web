using PashaBank.Services.Models.ResponseModels.Bonus;

namespace PashaBank.Services.Abstractions
{
    public interface IBonusService
    {
        Task<BonusResponse> CalculateUserBonusById(int userId, DateTime startDate, DateTime endDate);
    }
}

