using System.Threading;
using System.Threading.Tasks;
using CBC.TaskManagement.WebApi.Data;
using CBC.TaskManagement.WebApi.Domain;
using MediatR;

namespace TaskManagement.WebApi.Service.Command
{
    public class CreateTodoTaskCommandHandler : IRequestHandler<CreateTodoTaskCommand, TodoTask>
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public CreateTodoTaskCommandHandler(ITodoTaskRepository repository)
        {
            _todoTaskRepository = repository;
        }

        public async Task<TodoTask> Handle(CreateTodoTaskCommand request, CancellationToken cancellationToken)
        {
            return await _todoTaskRepository.AddAsync(request.Task);
        }
    }
}