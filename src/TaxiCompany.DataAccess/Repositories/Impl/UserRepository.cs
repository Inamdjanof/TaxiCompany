using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Core.Entities;
using TaxiCompany.DataAccess.Persistence;

namespace TaxiCompany.DataAccess.Repositories.Impl
{
    public class UserRepository : IUserRepository 
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext appDbContext) =>
            _databaseContext = appDbContext;

        public async ValueTask<User> InsertAsync(
            User user)
        {
            var userEntry = await _databaseContext.AddAsync(user);

            await SaveChangesAsync();

            return userEntry.Entity;
        }

        public IQueryable<User> SelectAll() =>
            _databaseContext.Set<User>();

        public async ValueTask<User> SelectByIdAsync(Guid id) =>
            await _databaseContext.Set<User>().FindAsync(id);

        public async ValueTask<User> SelectByIdWithDetailsAsync(
            Expression<Func<User, bool>> expression,
            string[] includes = null)
        {
            IQueryable<User> entities = this.SelectAll();

            foreach (var include in includes)
            {
                entities = entities.Include(include);
            }

            return await entities.FirstOrDefaultAsync(expression);
        }

        public async ValueTask<User> UpdateAsync(User user)
        {
            var userEntry = _databaseContext
                .Update<User>(user);

            await this.SaveChangesAsync();

            return userEntry.Entity;
        }

        public async ValueTask<User> DeleteAsync(User user)
        {
            var entityEntry = _databaseContext
                .Set<User>()
                .Remove(user);

            await this.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<int> SaveChangesAsync() =>
            await _databaseContext
                .SaveChangesAsync();

        public async Task<User?> SelectByEmailAsync(string email)
        {
            // Elektron pochta bo'yicha foydalanuvchini topish
            return await _databaseContext.Users
                .FirstOrDefaultAsync(u => u.Email == email);  // Foydalanuvchi bo'yicha tekshirish
        }

    }
}
