using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        #region Create
        /// <summary>
        /// Sends owner to data layer, to be created
        /// </summary>
        /// <param name="owner">Owner to create</param>
        /// <returns>Newly created owner</returns>
        Owner CreateOwner(Owner owner);
        #endregion

        #region Read
        /// <summary>
        /// Gets all owners
        /// </summary>
        List<Owner> GetOwners();

        /// <summary>
        /// Searches for owner by name
        /// </summary>
        /// <param name="searchTerm">Name to search for</param>
        /// <returns>All matches to search term</returns>
        List<Owner> SearchByName(string searchTerm);

        /// <summary>
        /// Gets owner by id
        /// </summary>
        /// <param name="id">id to search for</param>
        /// <returns>Owner if found, else null</returns>
        Owner GetOwnerById(int id);
        #endregion

        #region Update
        /// <summary>
        /// Send owner to data layer to be updated
        /// </summary>
        /// <param name="owner">Owner to be updated</param>
        /// <returns>True if update was a success</returns>
        Owner UpdateOwner(Owner owner);
        #endregion

        #region Delete
        /// <summary>
        /// Sends owner to data layer to be deleted
        /// </summary>
        /// <param name="id">Id of owner to delete</param>
        /// <returns>True if deletion was a success</returns>
        Owner DeleteOwner(int id);
        #endregion
    }
}