using System;
using CBC.TaskManagement.WebApi.TodoTasksApi.Domain;
using MediatR;

namespace CBC.TaskManagement.WebApi.TodoTasksApi.Service.Query
{
   public class GetTodoTaskByIdQuery : IRequest<TodoTask>
    {
        public Guid Id { get; set; }
    }
}
