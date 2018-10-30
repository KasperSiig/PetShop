using System.Linq;
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

        public User ReadUser(string username)
        {
            return _ctx.Users.FirstOrDefault(u => u.Username.ToLower().Equals(username.ToLower()));
        }
    }
}