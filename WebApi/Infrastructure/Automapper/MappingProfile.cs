
namespace CBC.TaskManagement.WebApi.Automapper
{
    using AutoMapper;
    using CBC.TaskManagement.WebApi.Domain;
    using CBC.TaskManagement.WebApi.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoTaskModel, TodoTask>()
                .ForMember(x => x.Status, opt => opt.MapFrom(src => 0));
        }
    }
}