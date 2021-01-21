using CBC.TaskManagement.WebApi.Domain;
using MediatR;

namespace TaskManagement.WebApi.Service.Command
{
    public class DeleteTodoTaskCommand : IRequest
    {
        public TodoTask Task { get; set; }
    }
}
