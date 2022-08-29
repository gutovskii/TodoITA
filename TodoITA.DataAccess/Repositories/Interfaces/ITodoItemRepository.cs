using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoITA.DataAccess.Entities;

namespace TodoITA.DataAccess.Repositories.Interfaces
{
    public interface ITodoItemRepository : IBaseRepository<TodoItem>
    {
        public Task<TodoItem> GetByIdAsync(int id);
        public Task UpdatePatchAsync(TodoItem todoItem, JsonPatchDocument<TodoItem> patchDocument);
    }
}
