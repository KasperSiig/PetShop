using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PetShopContext _ctx;

        public OwnerRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public Owner CreateOwner(Owner owner)
        {
            var newOwner = _ctx.Add(owner).Entity;
            _ctx.SaveChanges();
            return newOwner;
        }

        public Owner ReadOwnerById(int id)
        {
            return _ctx.Owners
                .Include(o => o.Pets)
                .FirstOrDefault(owner => owner.Id.Equals(id));
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _ctx.Owners;
        }

        public Owner UpdateOwner(Owner owner)
        {
            var ownerUpdated = _ctx.Update(owner).Entity;
            _ctx.SaveChanges();
            return ownerUpdated;
        }

        public Owner DeleteOwner(int id)
        {
            var ownerRemoved = _ctx.Remove(new Owner() {Id = id}).Entity;
            _ctx.SaveChanges();
            return ownerRemoved;
        }
    }
}