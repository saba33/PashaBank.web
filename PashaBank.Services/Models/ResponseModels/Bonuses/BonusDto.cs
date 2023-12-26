namespace PashaBank.Services.Models.ResponseModels.Bonuses
{
    public class BonusDto
    {
        public decimal TotalVolumeSalesBonus { get; set; }
        public decimal SelfSalesBonus { get; set; }
        public decimal RecommendedDistributorsBonus { get; set; }
        public decimal SecondLevelSalesBonus { get; set; }

        public DateTime BonusAssignDate { get; set; } = DateTime.Now;
    }
}
