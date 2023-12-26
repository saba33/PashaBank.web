using PashaBank.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PashaBank.Core.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}