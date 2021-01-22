using System.Threading;
using System.Threading.Tasks;
using CBC.TaskManagement.WebApi.TodoTasksApi.Data.Repository;
using CBC.TaskManagement.WebApi.TodoTasksApi.Domain;
using MediatR;

namespace CBC.TaskManagement.WebApi.TodoTasksApi.Service.Query
{
    public class GetTodoTaskByIdQueryHandler : IRequestHandler<GetTodoTaskByIdQuery, TodoTask>
    {
        private readonly ITodoTaskRepository _repository;

        public GetTodoTaskByIdQueryHandler(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoTask> Handle(GetTodoTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetTaskByIdAsync(request.Id, cancellationToken);
        }
    }
}