using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopContext _ctx;

        public PetRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public Pet CreatePet(Pet pet)
        {
            if (pet.PreviousOwner != null &&
                _ctx.ChangeTracker.Entries<Owner>()
                    .FirstOrDefault(ce => ce.Entity.Id == pet.PreviousOwner.Id) == null)
            {
                _ctx.Attach(pet.PreviousOwner);
            }

            var petSaved = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return petSaved;
        }

        public IEnumerable<Pet> ReadPets(Filter filter = null)
        {
            if (filter == null ||
                filter.CurrentPage == 0 && filter.ItemsPerPage == 0)
            {
                return _ctx.Pets;
            }

            return _ctx.Pets
                .Skip((filter.CurrentPage - 1) * filter.ItemsPerPage)
                .Take(filter.ItemsPerPage);
        }

        public IEnumerable<Pet> SearchByType(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();
            return _ctx.Pets.Where(pet => pet.Type.ToString().ToLower().Contains(searchTerm));
        }

        public Pet ReadPetById(int id)
        {
            return _ctx.Pets
                .Include(pet => pet.PreviousOwner)
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public bool UpdatePet(Pet pet)
        {
            if (pet.PreviousOwner != null && _ctx.ChangeTracker.Entries<Owner>()
                    .FirstOrDefault(ce => ce.Entity.Id == pet.PreviousOwner.Id) == null)
            {
                _ctx.Attach(pet.PreviousOwner);
            }
            else
            {
                _ctx.Entry(pet).Reference(p => p.PreviousOwner).IsModified = true;
            }

            var petUpdated = _ctx.Pets.Update(pet).Entity;
            _ctx.SaveChanges();
            return true;
        }

        public bool DeletePet(int id)
        {
            _ctx.Pets.Remove(ReadPetById(id));
            _ctx.SaveChanges();
            return true;
        }

        public int Count()
        {
           return _ctx.Pets.Count();
        }
    }
}