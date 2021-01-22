using CBC.TaskManagement.WebApi.TodoTasksApi.Domain;
using MediatR;

namespace CBC.TaskManagement.WebApi.TodoTasksApi.Service.Command
{
    public class DeleteTodoTaskCommand : IRequest
    {
        public TodoTask Task { get; set; }
    }
}
