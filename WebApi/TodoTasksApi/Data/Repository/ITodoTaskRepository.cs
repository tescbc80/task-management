using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CBC.TaskManagement.WebApi.TodoTasksApi.Domain;

namespace CBC.TaskManagement.WebApi.TodoTasksApi.Data.Repository
{
    /// <summary>
    /// Abstracts specific method related to <see cref="TodoTask"/>.
    /// </summary>
    public interface ITodoTaskRepository: IRepository<TodoTask>
    {
        /// <summary>
        /// Gets the all of <see cref="TodoTask"/>.
        /// </summary>
        /// <param name="cancellation">The <see cref="CancellationToken"/> object.</param>
        /// <returns></returns>
        Task<List<TodoTask>> GetTasksAsync(CancellationToken cancellation);

        /// <summary>
        /// Find the <see cref="TodoTask"/> by id.
        /// </summary>
        /// <param name="taskId">The unique identifier.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object.</param>
        /// <returns></returns>
        Task<TodoTask> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken);
    }
}