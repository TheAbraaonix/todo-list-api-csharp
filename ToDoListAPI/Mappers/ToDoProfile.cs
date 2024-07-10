using AutoMapper;
using ToDoListAPI.Entities;
using ToDoListAPI.Models;

namespace ToDoListAPI.Mappers
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDo, ToDoViewModel>();
            CreateMap<ToDoInputModel, ToDo>();
        }
    }
}
