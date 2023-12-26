using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PashaBank.Services.Abstractions;
using PashaBank.Services.Models.RequestModels.Product;
using PashaBank.Services.Models.ResponseModels.ProductsAndSales;

namespace PashaBank.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductSaleService _productSaleService;
        public ProductController(IProductSaleService productSaleService)
        {
            _productSaleService = productSaleService;
        }

        [Authorize]
        [HttpPost("AddProduct")]
        public async Task<ActionResult<AddProductResponse>> AddProduct(ProductDto entity)
        {
            return await _productSaleService.AddProduct(entity);
        }


        [Authorize]
        [HttpGet("GetProducts")]
        public async Task<ActionResult<GetProductsResponse>> GetProducts(ProductDto entity)
        {
            return await _productSaleService.GetProducts();
        }

        [Authorize]
        [HttpGet("UpdateProduct")]
        public async Task<ActionResult<UpdateProductResponse>> UpdateProduct(ProductDto entity, int productId)
        {
            return await _productSaleService.UpdateProduct(entity, productId);
        }

    }
}
