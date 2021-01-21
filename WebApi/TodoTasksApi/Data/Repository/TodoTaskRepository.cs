using CBC.TaskManagement.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CBC.TaskManagement.WebApi.Data
{
    public class TodoTaskRepository : Repository<TodoTask>, ITodoTaskRepository
    {
        public TodoTaskRepository(TodoTaskContext dbContext) : base(dbContext)
        {
        }

        public async Task<TodoTask> GetTaskByIdAsync(int taskId, CancellationToken cancellationToken)
        {
            return await DBContext.TodoTasks.FirstOrDefaultAsync(x => x.Id == taskId, cancellationToken);
        }

        public async Task<List<TodoTask>> GetTasksAsync(CancellationToken cancellationToken)
        {
            try
            {
                var result = await this.DBContext.TodoTasks.ToListAsync(cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities {ex.Message}");
            }
            
        }
    }
}