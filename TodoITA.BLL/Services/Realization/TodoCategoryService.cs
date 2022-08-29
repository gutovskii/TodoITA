using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoITA.BLL.Services.Interfaces;
using TodoITA.DataAccess.Entities;
using TodoITA.DataAccess.Repositories.Interfaces;

namespace TodoITA.BLL.Services.Realization
{
    public class TodoCategoryService : ITodoCategoryService
    {
        private ITodoCategoryRepository _todoCategoryRepository;
        public TodoCategoryService(ITodoCategoryRepository todoCategoryRepository)
        {
            _todoCategoryRepository = todoCategoryRepository;
        }

        public async Task<IEnumerable<TodoCategory>> GetTodoCategoriesAsync()
        {
            var categories = await _todoCategoryRepository.GetAllAsync();
            return categories;
        }

        public async Task<TodoCategory> GetTodoCaterogyByIdAsync(int id)
        {
            var category = await _todoCategoryRepository.GetByIdAsync(id);
            return category;
        }

        public async Task CreateTodoCategoryAsync(TodoCategory todoCaterogy)
        {
            await _todoCategoryRepository.CreateAsync(todoCaterogy);
        }

        public async Task UpdateTodoCategoryAsync(TodoCategory todoCaterogy)
        {
            await _todoCategoryRepository.UpdateAsync(todoCaterogy);
        }

        public async Task<bool> DeleteTodoCategoryAsync(int id)
        {
            var isDeleted = await _todoCategoryRepository.DeleteAsync(id);
            if (!isDeleted) return false;
            return true;
        }
    }
}
