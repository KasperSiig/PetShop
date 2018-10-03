using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        #region Create
        /// <summary>
        /// Sends pet to data layer to be created
        /// </summary>
        /// <param name="pet">Pet to be created</param>
        /// <returns>Newly created pet</returns>
        Pet CreatePet(Pet pet);
        #endregion

        #region Read
        /// <summary>
        /// Gets all pets from storage
        /// </summary>
        List<Pet> GetPets();

        /// <summary>
        /// Searches for pets by type
        /// </summary>
        /// <param name="searchTerm">Search term to match</param>
        /// <returns>All matches to search term</returns>
        List<Pet> SearchByType(string searchTerm);

        /// <summary>
        /// Gets five cheapest pets available
        /// </summary>
        List<Pet> GetFiveCheapest();

        /// <summary>
        /// Returns list of all pets, sorted by price
        /// </summary>
        List<Pet> SortPetsByPrice();

        /// <summary>
        /// Gets pet by given ID
        /// </summary>
        /// <param name="id">Id of pet to get</param>
        /// <returns>Pet if found, else null</returns>
        Pet GetPetById(int id);

        /// <summary>
        /// Provides pets in a paginated result
        /// </summary>
        /// <param name="filter">Parameter to get filters by</param>
        /// <returns>Filtered Pets</returns>
        List<Pet> GetFilteredOrders(Filter filter);

        #endregion

        #region Update

        /// <summary>
        /// Updates pet
        /// </summary>
        /// <param name="pet">Pet to be updated</param>
        /// <returns>True if update was a success</returns>
        bool UpdatePet(Pet pet);

        #endregion

        #region Delete

        /// <summary>
        /// Deletes pet
        /// </summary>
        /// <param name="id">Id of pet to delete</param>
        /// <returns>True if deletion was a success</returns>
        bool DeletePet(int id);

        #endregion
    }
}