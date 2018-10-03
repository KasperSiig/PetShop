using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        #region Create
        /// <summary>
        /// Creates owner in storage
        /// </summary>
        /// <param name="owner">Owner to be inserted into storage</param>
        /// <returns>Newly created owner</returns>
        Owner CreateOwner(Owner owner);
        #endregion

        #region Read
        /// <summary>
        /// Reads owner by Id
        /// </summary>
        /// <param name="id">Id of owner be read</param>
        /// <returns>Owner if found, else null</returns>
        Owner ReadOwnerById(int id);

        /// <summary>
        /// Reads all owners
        /// </summary>
        IEnumerable<Owner> ReadOwners();
        #endregion

        #region Update
        /// <summary>
        /// Updates owner in storage
        /// </summary>
        /// <param name="owner">Owner to update</param>
        /// <returns>True if update was a success</returns>
        Owner UpdateOwner(Owner owner);
        #endregion

        #region Delete
        /// <summary>
        /// Deletes owner from storage
        /// </summary>
        /// <param name="id">Id of owner to delete</param>
        /// <returns>True if deletion was a success</returns>
        Owner DeleteOwner(int id);
        #endregion
    }
}