using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        #region Create
        /// <summary>
        /// Creates pet from given parameter
        /// </summary>
        /// <param name="pet">Pet to be inserted in storage</param>
        /// <returns>Newly created pet with new Id</returns>
        Pet CreatePet(Pet pet);
        #endregion

        #region Read
        /// <summary>
        /// Reads all pets from storage
        /// </summary>
        IEnumerable<Pet> ReadPets(Filter filter = null);

        /// <summary>
        /// Searches by pet type
        /// </summary>
        /// <param name="searchTerm">Term to search for</param>
        /// <returns>All matches to search term</returns>
        IEnumerable<Pet> SearchByType(string searchTerm);
        Pet ReadPetById(int id);
        #endregion

        #region Update
        /// <summary>
        /// Updates pet in storage
        /// </summary>
        /// <param name="pet">Pet with new information</param>
        /// <returns>True if update was a success</returns>
        bool UpdatePet(Pet pet);
        #endregion

        #region Delete
        /// <summary>
        /// Deletes pet from storage
        /// </summary>
        /// <param name="id">Id of pet to delete</param>
        /// <returns>True if deletion was a success</returns>
        bool DeletePet(int id);
        #endregion

        int Count();
    }
}