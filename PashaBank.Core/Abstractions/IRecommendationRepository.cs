using PashaBank.Core.Models;

namespace PashaBank.Core.Abstractions
{
    public interface IRecommendationRepository : IGenericRepository<Recommendation>
    {
        Task<IEnumerable<Recommendation>> GetRecommendationsByRecommenderId(int recommenderId);
    }
}
