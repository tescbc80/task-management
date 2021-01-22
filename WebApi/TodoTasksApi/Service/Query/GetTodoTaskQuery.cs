using System.Collections.Generic;
using CBC.TaskManagement.WebApi.TodoTasksApi.Domain;
using MediatR;

namespace CBC.TaskManagement.WebApi.TodoTasksApi.Service.Query
{
    public class GetTodoTaskQuery : IRequest<List<TodoTask>>
    {
    }
}
