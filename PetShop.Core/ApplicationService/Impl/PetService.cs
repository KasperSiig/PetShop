using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepo;
        private IOwnerRepository _ownerRepo;

        public PetService(IPetRepository petRepo,
                            IOwnerRepository ownerRepository)
        {
            _petRepo = petRepo;
            _ownerRepo = ownerRepository;
        }

        #region Create
        public Pet CreatePet(Pet pet)
        {
            pet.SoldDate = DateTime.MinValue;
            return _petRepo.CreatePet(pet);
        }
        #endregion

        #region Read
        public List<Pet> GetPets()
        {
            var pets = _petRepo.ReadPets();
            return pets.ToList();
        }

        public List<Pet> SearchByType(string searchTerm)
        {
            var pets = _petRepo.SearchByType(searchTerm);
            return pets.ToList();
        }

        public List<Pet> GetFiveCheapest()
        {
            return _petRepo.ReadPets().OrderBy(pet => pet.Price)
                .Where(pet => pet.SoldDate == DateTime.MinValue).ToList();
        }

        public List<Pet> SortPetsByPrice()
        {
            return _petRepo.ReadPets().OrderBy(pet => pet.Price).ToList();
        }

        public Pet GetPetById(int id)
        {
            var pet = _petRepo.ReadPetById(id);
            return pet;
        }

        public List<Pet> GetFilteredOrders(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPerPage < 0)
                throw new InvalidDataException("CurrentPage and ItemsPerPage must be zero or more");
            
            return _petRepo.ReadPets(filter).ToList();
        }

        #endregion

        #region Update
        public bool UpdatePet(Pet pet)
        {
            return _petRepo.UpdatePet(pet);
        }
        #endregion

        #region Delete
        public bool DeletePet(int id)
        {
            return _petRepo.DeletePet(id);
        }
        #endregion
    }
}