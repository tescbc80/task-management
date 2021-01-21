namespace TaskManagement.WebApi.Service.Query
{
    using CBC.TaskManagement.WebApi.Domain;
    using MediatR;
    using System.Collections.Generic;


    public class GetTodoTaskQuery : IRequest<List<TodoTask>>
    {
    }
}
