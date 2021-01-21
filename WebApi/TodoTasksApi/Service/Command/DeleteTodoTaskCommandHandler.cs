using System.Threading;
using System.Threading.Tasks;
using CBC.TaskManagement.WebApi.Data;
using CBC.TaskManagement.WebApi.Domain;
using MediatR;

namespace TaskManagement.WebApi.Service.Command
{
    public class DeleteTodoTaskCommandHandler : IRequestHandler<DeleteTodoTaskCommand>
    {
        private readonly ITodoTaskRepository _repository;

        public DeleteTodoTaskCommandHandler(ITodoTaskRepository repository)
        {
            _repository = repository;
        }

      
        public async Task<Unit> Handle(DeleteTodoTaskCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Task);
            return Unit.Value;
        }
    }
}