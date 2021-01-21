
namespace TaskManagement.WebApi.Service.Command
{
    using CBC.TaskManagement.WebApi.Domain;
    using MediatR;

    public class CreateTodoTaskCommand : IRequest<TodoTask>
    {
        public TodoTask Task { get; set; }
    }
}
