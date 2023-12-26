using PashaBank.Core.Abstractions;
using PashaBank.Core.Models;
using PashaBank.Repository.DataContext;

namespace PashaBank.Repository.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
