﻿using VeggieVibes.Domain.Entities;

namespace VeggieVibes.Domain.Repositories
{
    public interface IRecipesWriteOnlyRepository
    {
        Task Add(Recipe recipe);
        /// <summary>
        /// This function returns true if the deletion was successful, false otherwise.
        /// </summary>
        /// <param name="id">Recipe ID to delete</param>
        /// <returns>True if recipe was found and deleted, false otherwise</returns>
        Task<bool> Delete(long id);
    }
}
