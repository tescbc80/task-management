using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBC.TaskManagement.WebApi.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// TODO: Think if we need to make this generic too,
        /// </summary>
        protected readonly TodoTaskContext DBContext;

        public Repository(TodoTaskContext  dbContext)
        {
            DBContext = dbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await DBContext.AddAsync(entity);
                await DBContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                DBContext.Update(entity);
                await DBContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated {ex.Message}");
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null");
            }

            try
            {
                DBContext.Remove(entity);
                await DBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be deleted {ex.Message}");
            }
        }
    }
}