using PashaBank.Services.Models.RequestModels.Sales;

namespace PashaBank.Services.Models.ResponseModels.ProductsAndSales
{
    public class GetSaleResponse : BaseResponse
    {
        public List<SaleDto> Sales { get; set; }
    }
}
