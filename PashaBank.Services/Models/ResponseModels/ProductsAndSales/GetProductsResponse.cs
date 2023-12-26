using PashaBank.Services.Models.RequestModels.Product;

namespace PashaBank.Services.Models.ResponseModels.ProductsAndSales
{
    public class GetProductsResponse : BaseResponse
    {
        public List<ProductDto> Products { get; set; }
    }
}
