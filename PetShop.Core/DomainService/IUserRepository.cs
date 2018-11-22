using PetShop.Core.Entity;

namespace PetShop.Core.DomainService
{
    public interface IUserRepository
    {
        User ReadUserByUsername(string username);
    }
}