using System.Threading.Tasks;

namespace CBC.TaskManagement.WebApi.TodoTasksApi.Data.Repository
{
    /// <summary>
    /// Provides a generic class for repositories.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Adds a entity to db.
        /// </summary>
        /// <param name="entity">The added instance.</param>
        /// <returns>Returns the added object.</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Updates the entity.
        /// </summary>
        /// <param name="entity">The updating instance.</param>
        /// <returns>Returns the updated object.</returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// Deletes an entity from db.
        /// </summary>
        /// <param name="entity">The deleting instance.</param>
        /// <returns>Returns the deleted object.</returns>
        Task DeleteAsync(TEntity entity);
    }
}