using CBC.TaskManagement.WebApi.Domain;
using MediatR;

namespace TaskManagement.WebApi.Service.Command
{
    public class SetTaskStatusCommand : IRequest<TodoTask>
    {
        public TodoTask Task { get; set; }
    }
}
