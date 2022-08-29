using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoITA.DataAccess.Entities;
using TodoITA.BLL.DTO;

namespace TodoITA.BLL.Services.Interfaces
{
    public interface ITodoCategoryService
    {
        public Task<IEnumerable<TodoCategory>> GetTodoCategoriesAsync();
        public Task<TodoCategory> GetTodoCaterogyByIdAsync(int id);
        public Task CreateTodoCategoryAsync(TodoCategory todoCaterogy);
        public Task UpdateTodoCategoryAsync(TodoCategory todoCaterogy);
        public Task<bool> DeleteTodoCategoryAsync(int id);
    }
}
