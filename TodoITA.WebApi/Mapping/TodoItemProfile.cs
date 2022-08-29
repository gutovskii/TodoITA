using AutoMapper;
using TodoITA.WebApi.ViewModels;
using TodoITA.DataAccess.Entities;
using TodoITA.BLL.DTO.TodoItem;
using System.Collections;
using System.Collections.Generic;

namespace TodoITA.WebApi.Mapping
{
    public class TodoItemProfile : Profile
    {
        public TodoItemProfile()
        {
            CreateMap<CreateTodoItemDto, TodoItem>();
            CreateMap<UpdateTodoItemDto, TodoItem>();
            CreateMap<TodoItem, TodoItemViewModel>();
        }
    }
}
