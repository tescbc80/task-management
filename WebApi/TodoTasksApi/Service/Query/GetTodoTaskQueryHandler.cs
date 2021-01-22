using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CBC.TaskManagement.WebApi.TodoTasksApi.Data.Repository;
using CBC.TaskManagement.WebApi.TodoTasksApi.Domain;
using MediatR;

namespace CBC.TaskManagement.WebApi.TodoTasksApi.Service.Query
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