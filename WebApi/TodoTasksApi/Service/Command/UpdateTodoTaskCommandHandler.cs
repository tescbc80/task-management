using System.Threading;
using System.Threading.Tasks;
using CBC.TaskManagement.WebApi.TodoTasksApi.Data.Repository;
using CBC.TaskManagement.WebApi.TodoTasksApi.Domain;
using MediatR;

namespace CBC.TaskManagement.WebApi.TodoTasksApi.Service.Command
{
    public class UpdateTodoTaskCommandHandler : IRequestHandler<UpdateTodoTaskCommand, TodoTask>
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public UpdateTodoTaskCommandHandler(ITodoTaskRepository repository)
        {
            _todoTaskRepository = repository;
        }

        public async Task<TodoTask> Handle(UpdateTodoTaskCommand request, CancellationToken cancellationToken)
        {
            return await _todoTaskRepository.UpdateAsync(request.Task);
        }
    }
}