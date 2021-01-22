
using AutoMapper;
using CBC.TaskManagement.WebApi.Models;
using CBC.TaskManagement.WebApi.TodoTasksApi.Domain;

namespace CBC.TaskManagement.WebApi.Infrastructure.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoTaskModel, TodoTask>()
                .ForMember(x => x.Status, opt => opt.MapFrom(src => 0));
        }
    }
}