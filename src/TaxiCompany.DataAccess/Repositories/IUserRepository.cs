using System.Linq.Expressions;
using TaxiCompany.Core.Entities;

namespace TaxiCompany.DataAccess.Repositories;

public interface IUserRepository
{
    ValueTask<User> DeleteAsync(User user);
    ValueTask<User> InsertAsync(User user);
    ValueTask<int> SaveChangesAsync();
    ValueTask<User> SelectByIdAsync(Guid id);
    IQueryable<User> SelectAll();
    ValueTask<User> SelectByIdWithDetailsAsync(Expression<Func<User, bool>> expression, string[] includes = null);
    ValueTask<User> UpdateAsync(User user);
     Task<User?> SelectByEmailAsync(string email);
}