using Microsoft.AspNetCore.Http;
using PashaBank.Core.Abstractions;
using PashaBank.Core.Models;
using PashaBank.Services.Abstractions;
using PashaBank.Services.Models.ResponseModels.Bonus;
using PashaBank.Services.Models.ResponseModels.Bonuses;

namespace PashaBank.Services.Implementation
{
    public class BonusService : IBonusService
    {
        private readonly IRecomendationServices _recomendationServices;
        private readonly IProductSaleService _productSaleService;
        private readonly IUnitOfWork _unit;
        private readonly IProductSaleService _saleService;
        public BonusService(IRecomendationServices recomendationServices, IProductSaleService saleService, IProductSaleService productSaleService, IUnitOfWork unit)
        {
            _recomendationServices = recomendationServices;
            _productSaleService = productSaleService;
            _unit = unit;
            _saleService = saleService;
        }


        public async Task<BonusResponse> CalculateUserBonusById(int userId, DateTime startDate, DateTime endDate)
        {
            var saleResponse = await _saleService.GetSalesByUserId(userId, startDate, endDate);
            var sales = saleResponse.Sales;

            var totalVolumeSales = sales.Sum(s => s.SalePrice);
            var selfSaleBonus = 0.1m * totalVolumeSales;

            var firstLevelRecommendations = await _recomendationServices.GetRecommendationsAtLevel(userId, 1, 1, 1);
            var firstLevelBonusAmount = firstLevelRecommendations
                .Sum(item => _productSaleService.GetSalesByUserId
                   (item.RecommendedUserId, startDate, endDate).Result.Sales.Sum(s => s.SalePrice) * 0.05m);

            var secondLevelRecommendedUsers = new List<Recommendation>();
            foreach (var user in firstLevelRecommendations)
            {
                secondLevelRecommendedUsers.AddRange(await _recomendationServices.GetRecommendationsAtLevel(user.RecommendedUserId, 2, 2, 2));
            }
            var secondLevelBonusAmount = secondLevelRecommendedUsers.
                Sum(item => _productSaleService.GetSalesByUserId
                       (item.RecommendedUserId, startDate, endDate).Result.Sales.Sum(s => s.SalePrice) * 0.01m);

            var totalBonusAmount = selfSaleBonus + firstLevelBonusAmount + secondLevelBonusAmount;

            var bonusDto = new BonusDto
            {
                SelfSalesBonus = selfSaleBonus,
                SecondLevelSalesBonus = secondLevelBonusAmount,
                RecommendedDistributorsBonus = firstLevelBonusAmount,
                TotalVolumeSalesBonus = totalBonusAmount
            };

            return new BonusResponse
            {
                Bonus = bonusDto,
                Message = "Bonus Successfully calculated",
                StatusCode = StatusCodes.Status200OK
            };
        }

    }
}
