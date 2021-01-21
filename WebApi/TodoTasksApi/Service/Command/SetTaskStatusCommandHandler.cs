using System.Threading;
using System.Threading.Tasks;
using CBC.TaskManagement.WebApi.Data;
using CBC.TaskManagement.WebApi.Domain;
using MediatR;

namespace TaskManagement.WebApi.Service.Command
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