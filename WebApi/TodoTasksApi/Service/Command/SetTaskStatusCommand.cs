using CBC.TaskManagement.WebApi.TodoTasksApi.Domain;
using MediatR;

namespace CBC.TaskManagement.WebApi.TodoTasksApi.Service.Command
{
    public class SetTaskStatusCommand : IRequest<TodoTask>
    {
        public TodoTask Task { get; set; }
    }
}
