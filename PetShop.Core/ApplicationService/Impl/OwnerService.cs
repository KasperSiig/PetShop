using System.Collections.Generic;
using System.Linq;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Impl
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        #region Create
        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepository.CreateOwner(owner);
        }
        #endregion

        #region Read
        public List<Owner> GetOwners()
        {
            var owners = _ownerRepository.ReadOwners().ToList();
            return owners;
        }

        public List<Owner> SearchByName(string searchTerm)
        {
            var owners = _ownerRepository.ReadOwners().Where((owner =>
            {
                var fullName = owner.FirstName + ' ' + owner.LastName;
                fullName = fullName.ToLower();
                return fullName.Contains(searchTerm);
            }));

            return owners.ToList();
        }

        public Owner GetOwnerById(int id)
        {
            return _ownerRepository.ReadOwnerById(id);
        }
        #endregion

        #region Update
        public Owner UpdateOwner(Owner owner)
        {
            return _ownerRepository.UpdateOwner(owner);
        }
        #endregion

        #region Delete
        public Owner DeleteOwner(int id)
        {
            return _ownerRepository.DeleteOwner(id);
        }
        #endregion 
    }
}