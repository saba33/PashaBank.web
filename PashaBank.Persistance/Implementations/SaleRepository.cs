using PashaBank.Core.Abstractions;
using PashaBank.Core.Models.Enums;
using PashaBank.Repository.DataContext;

namespace PashaBank.Repository.Implementations
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        public SaleRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
