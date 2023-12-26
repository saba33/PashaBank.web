using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PashaBank.Core.Models
{
    public class Bonus
    {
        [Key]
        public int BonusId { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User Distributor { get; set; }

        public decimal TotalVolumeSalesBonus { get; set; }
        public decimal SelfSalesBonus { get; set; }
        public decimal RecommendedDistributorsBonus { get; set; }
        public decimal SecondLevelSalesBonus { get; set; }

        public DateTime BonusAssignDate { get; set; } = DateTime.Now;
    }
}
