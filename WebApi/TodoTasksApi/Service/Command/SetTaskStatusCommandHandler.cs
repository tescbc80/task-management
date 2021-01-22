using System.Threading;
using System.Threading.Tasks;
using CBC.TaskManagement.WebApi.TodoTasksApi.Data.Repository;
using CBC.TaskManagement.WebApi.TodoTasksApi.Domain;
using MediatR;

namespace CBC.TaskManagement.WebApi.TodoTasksApi.Service.Command
{
    public class SetTaskStatusCommandHandler : IRequestHandler<SetTaskStatusCommand, TodoTask>
    {
        private readonly ITodoTaskRepository _repository;

        public SetTaskStatusCommandHandler(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoTask> Handle(SetTaskStatusCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(request.Task);
        }
    }
}