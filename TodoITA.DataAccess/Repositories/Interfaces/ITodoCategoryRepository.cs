using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoITA.DataAccess.Entities;

namespace TodoITA.DataAccess.Repositories.Interfaces
{
    public interface ITodoCategoryRepository : IBaseRepository<TodoCategory>
    {
        public Task<IEnumerable<TodoCategory>> GetAllAsync();
        public Task<TodoCategory> GetByIdAsync(int id);
    }
}
