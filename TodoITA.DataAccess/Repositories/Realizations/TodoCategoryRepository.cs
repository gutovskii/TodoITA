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
    public class TodoCategoryRepository : BaseRepository<TodoCategory>, ITodoCategoryRepository
    {
        private readonly TodoDbContext _db;
        public TodoCategoryRepository(TodoDbContext db)
            : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TodoCategory>> GetAllAsync()
        {
            var entities = await _db.TodoCategories.ToListAsync();
            return entities;
        }

        public async Task<TodoCategory> GetByIdAsync(int id)
        {
            var entity = await _db.TodoCategories
                .Select(tc => new TodoCategory { 
                    Id = tc.Id, 
                    Title = tc.Title, 
                    TodoItems = tc.TodoItems.OrderBy(ti => ti.IsDone).ToList()
                })
                .SingleOrDefaultAsync(tc => tc.Id == id);
            return entity;
        }
    }
}
