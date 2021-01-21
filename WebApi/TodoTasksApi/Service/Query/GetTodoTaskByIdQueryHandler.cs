using System.Threading;
using System.Threading.Tasks;
using CBC.TaskManagement.WebApi.Data;
using CBC.TaskManagement.WebApi.Domain;
using MediatR;

namespace TaskManagement.WebApi.Service.Query
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