using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoITA.BLL.DTO;
using TodoITA.BLL.Services.Interfaces;
using TodoITA.DataAccess.Entities;
using TodoITA.DataAccess.Repositories.Interfaces;

namespace TodoITA.BLL.Services.Realization
{
    public class TodoItemService : ITodoItemService
    {
        private ITodoItemRepository _todoItemRepository;
        public TodoItemService(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<TodoItem> GetTodoItemByIdAsync(int id)
        {
            var item = await _todoItemRepository.GetByIdAsync(id);
            if (item == null) return null;
            return item;
        }

        public async Task CreateTodoItemAsync(TodoItem todoItem)
        {
            await _todoItemRepository.CreateAsync(todoItem);
        }

        public async Task UpdateTodoItemAsync(TodoItem todoItem)
        {
            await _todoItemRepository.UpdateAsync(todoItem);
        }

        public async Task UpdateTodoItemPatchAsync(TodoItem todoItem, JsonPatchDocument<TodoItem> patchDocument)
        {
            await _todoItemRepository.UpdatePatchAsync(todoItem, patchDocument);
        }

        public async Task<bool> DeleteTodoItemAsync(int id)
        {
            var isDeleted = await _todoItemRepository.DeleteAsync(id);
            if (!isDeleted) return false;
            return true;
        }
    }
}
