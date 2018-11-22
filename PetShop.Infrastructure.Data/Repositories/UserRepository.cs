using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PetShopContext _ctx;

        public UserRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        
        public User ReadUserByUsername(string username)
        {
            return _ctx.Users.FirstOrDefault(u => u.Username.ToLower().Equals(username.ToLower()));
        }
        
        public IEnumerable<User> GetAll()
        {
            return _ctx.Users.ToList();
        }

        public User ReadUserById(long id)
        {
            return _ctx.Users.FirstOrDefault(b => b.Id == id);
        }

        public void Add(User entity)
        {
            _ctx.Users.Add(entity);
            _ctx.SaveChanges();
        }

        public void Edit(User entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void Remove(long id)
        {
            var item = _ctx.Users.FirstOrDefault(b => b.Id == id);
            _ctx.Users.Remove(item);
            _ctx.SaveChanges();
        }
    }
}