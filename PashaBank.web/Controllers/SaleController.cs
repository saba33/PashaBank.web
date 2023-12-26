using Microsoft.AspNetCore.Mvc;
using PashaBank.Services.Abstractions;
using PashaBank.Services.Models.RequestModels.Sales;
using PashaBank.Services.Models.ResponseModels.Sales;

namespace PashaBank.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IProductSaleService _productSaleService;
        public SaleController(IProductSaleService productSaleService)
        {
            _productSaleService = productSaleService;
        }

        [HttpPost("CreateSale")]
        public async Task<ActionResult<CreateSaleResponse>> CreateSale(SaleDto entity)
        {
            return await _productSaleService.AddSale(entity);
        }
    }
}
