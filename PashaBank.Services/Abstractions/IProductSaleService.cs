using PashaBank.Services.Models.RequestModels.Product;
using PashaBank.Services.Models.RequestModels.Sales;
using PashaBank.Services.Models.ResponseModels.ProductsAndSales;
using PashaBank.Services.Models.ResponseModels.Sales;

namespace PashaBank.Services.Abstractions
{
    public interface IProductSaleService
    {
        Task<UpdateProductResponse> UpdateProduct(ProductDto entity, int id);
        Task<CreateSaleResponse> AddSale(SaleDto entity);
        Task<AddProductResponse> AddProduct(ProductDto entity);
        Task<GetSaleResponse> GetSalesByUserId(int userId, DateTime StartDate, DateTime EndDate);
        Task<GetProductsResponse> GetProducts();
    }
}
