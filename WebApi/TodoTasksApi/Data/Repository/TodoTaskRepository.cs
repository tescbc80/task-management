using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CBC.TaskManagement.WebApi.TodoTasksApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace CBC.TaskManagement.WebApi.TodoTasksApi.Data.Repository
{
    /// <summary>
    /// Represents a object for CRUD action for <see cref="TodoTask"/>.
    /// </summary>
    public class TodoTaskRepository : Repository<TodoTask>, ITodoTaskRepository
    {
        public TodoTaskRepository(TodoTaskContext dbContext) : base(dbContext)
        {
        }

        public async Task<TodoTask> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken)
        {
            return await DbContext.TodoTasks.FirstOrDefaultAsync(x => x.Id == taskId, cancellationToken);
        }

        public async Task<List<TodoTask>> GetTasksAsync(CancellationToken cancellationToken)
        {
            try
            {
                var result = await this.DbContext.TodoTasks.ToListAsync(cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities {ex.Message}");
            }
            
        }
    }
}