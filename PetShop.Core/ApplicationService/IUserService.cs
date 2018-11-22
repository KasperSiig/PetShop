using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
    public interface IUserService
    {
        User GetUser(string username);
    }
}