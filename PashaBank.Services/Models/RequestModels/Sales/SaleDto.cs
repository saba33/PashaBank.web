using PashaBank.Services.Models.RequestModels.Product;

namespace PashaBank.Services.Models.RequestModels.Sales
{
    public class SaleDto
    {
        public int UserId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SalePrice { get; set; }
        public ICollection<ProductDto> SoldProducts { get; set; }
    }
}
