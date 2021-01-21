using System;
using CBC.TaskManagement.WebApi.Domain;
using MediatR;

namespace TaskManagement.WebApi.Service.Query
{
   public class GetTodoTaskByIdQuery : IRequest<TodoTask>
    {
        public Guid Id { get; set; }
    }
}
