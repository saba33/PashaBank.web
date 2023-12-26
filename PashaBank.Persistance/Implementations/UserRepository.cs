using PashaBank.Core.Abstractions;
using PashaBank.Core.Models;
using PashaBank.Repository.DataContext;
using System.Linq.Expressions;

namespace PashaBank.Repository.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context) { }


        public async Task<User> FindUserAsync(Expression<Func<User, bool>> predicate)
        {
            var result = await this.FindAsync(predicate);
            return result.FirstOrDefault();
        }

    }
}