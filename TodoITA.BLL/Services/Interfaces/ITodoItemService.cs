using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoITA.DataAccess.Entities;
using TodoITA.BLL.DTO;
using Microsoft.AspNetCore.JsonPatch;

namespace TodoITA.BLL.Services.Interfaces
{
    public interface ITodoItemService
    {
        public Task<TodoItem> GetTodoItemByIdAsync(int id);
        public Task CreateTodoItemAsync(TodoItem todoItem);
        public Task UpdateTodoItemAsync(TodoItem todoItem);
        public Task UpdateTodoItemPatchAsync(TodoItem todoItem, JsonPatchDocument<TodoItem> patchDocument);
        public Task<bool> DeleteTodoItemAsync(int id);
    }
}
