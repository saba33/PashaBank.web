using PashaBank.Core.Abstractions;
using PashaBank.Core.Models;
using PashaBank.Repository.DataContext;

namespace PashaBank.Repository.Implementations
{
    public class RecommendationRepository : GenericRepository<Recommendation>, IRecommendationRepository
    {
        public RecommendationRepository(DatabaseContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Recommendation>> GetRecommendationsByRecommenderId(int recommenderId)
        {
            return await this.FindAsync(r => r.RecommenderId == recommenderId);
        }
    }
}
