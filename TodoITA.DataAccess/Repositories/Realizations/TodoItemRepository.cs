using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoITA.DataAccess.Entities;
using TodoITA.DataAccess.Repositories.Interfaces;

namespace TodoITA.DataAccess.Repositories.Realizations
{
    public class TodoItemRepository : BaseRepository<TodoItem>, ITodoItemRepository
    {
        private readonly TodoDbContext _db;
        public TodoItemRepository(TodoDbContext db)
            : base(db)
        {
            _db = db;
        }

        public async Task<TodoItem> GetByIdAsync(int id)
        {
            var entity = await _db.TodoItems.FindAsync(id);
            if (entity == null) return null;
            return entity;
        }

        public async Task UpdatePatchAsync(TodoItem todoItem, JsonPatchDocument<TodoItem> patchDocument)
        {
            patchDocument.ApplyTo(todoItem);
            await _db.SaveChangesAsync();
        }
    }
}
