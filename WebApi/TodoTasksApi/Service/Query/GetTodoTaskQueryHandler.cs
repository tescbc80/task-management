using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CBC.TaskManagement.WebApi.Data;
using CBC.TaskManagement.WebApi.Domain;
using MediatR;

namespace TaskManagement.WebApi.Service.Query
{
    public class GetTodoTaskQueryHandler : IRequestHandler<GetTodoTaskQuery, List<TodoTask>>
    {
        private readonly ITodoTaskRepository _todoTaskRepository;

        public GetTodoTaskQueryHandler(ITodoTaskRepository repository)
        {
            _todoTaskRepository = repository;
        }

        public async Task<List<TodoTask>> Handle(GetTodoTaskQuery request, CancellationToken cancellationToken)
        {
            return await _todoTaskRepository.GetTasksAsync(cancellationToken);
        }
    }
}