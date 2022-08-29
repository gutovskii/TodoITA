using AutoMapper;
using TodoITA.WebApi.ViewModels;
using TodoITA.DataAccess.Entities;
using TodoITA.BLL.DTO.TodoCategory;

namespace TodoITA.WebApi.Mapping
{
    public class TodoCategoryProfile : Profile
    {
        public TodoCategoryProfile()
        {
            CreateMap<CreateTodoCategoryDto, TodoCategory>();
            CreateMap<UpdateTodoCategoryDto, TodoCategory>();
            CreateMap<TodoCategory, TodoCategoryViewModel>();
        }
    }
}
