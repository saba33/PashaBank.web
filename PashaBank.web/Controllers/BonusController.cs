using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PashaBank.Services.Abstractions;
using PashaBank.Services.Models.ResponseModels.Bonus;

namespace PashaBank.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusController : ControllerBase
    {
        private readonly IBonusService _bonusService;
        public BonusController(IBonusService bonusService)
        {
            _bonusService = bonusService;
        }
        [Authorize]
        [HttpGet("CalculateBonus")]
        public async Task<ActionResult<BonusResponse>> CalculateBonus(int userId, DateTime startdate, DateTime endDate)
        {
            return await _bonusService.CalculateUserBonusById(userId, startdate, endDate);
        }
    }
}
