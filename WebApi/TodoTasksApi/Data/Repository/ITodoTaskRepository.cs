namespace CBC.TaskManagement.WebApi.Data
{
    using CBC.TaskManagement.WebApi.Domain;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ITodoTaskRepository: IRepository<TodoTask>
    {
        Task<List<TodoTask>> GetTasksAsync(CancellationToken cancellation);
        
        Task<TodoTask> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);
    }
}