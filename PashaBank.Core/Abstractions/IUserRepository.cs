using PashaBank.Core.Models;
using System.Linq.Expressions;

namespace PashaBank.Core.Abstractions
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindUserAsync(Expression<Func<User, bool>> predicate);
    }
}
