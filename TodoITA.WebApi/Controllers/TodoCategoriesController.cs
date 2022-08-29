using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoITA.DataAccess.Entities;
using TodoITA.BLL.DTO.TodoCategory;
using TodoITA.BLL.Services.Interfaces;
using AutoMapper;
using TodoITA.WebApi.ViewModels;

namespace TodoITA.WebApi.Controllers
{
    [Route("categories")]
    [ApiController]
    public class TodoCategoriesController : ControllerBase
    {
        private readonly ITodoCategoryService _todoCategoryService;
        private readonly IMapper _mapper;
        public TodoCategoriesController(ITodoCategoryService todoCategoryService, IMapper mapper)
        {
            _todoCategoryService = todoCategoryService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetCategories")]
        public async Task<IActionResult> GetCaterogies()
        {
            var categories = await _todoCategoryService.GetTodoCategoriesAsync();
            var categoriesViewModel = _mapper.Map<IEnumerable<TodoCategoryViewModel>>(categories);
            return Ok(categoriesViewModel);
        }

        [HttpGet]
        [Route("{id}", Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _todoCategoryService.GetTodoCaterogyByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateTodoCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryToCreate = _mapper.Map<TodoCategory>(dto);
            await _todoCategoryService.CreateTodoCategoryAsync(categoryToCreate);

            var categoryViewModel = _mapper.Map<TodoCategoryViewModel>(categoryToCreate);

            return CreatedAtAction(nameof(GetCategoryById), new { Id = categoryToCreate.Id }, categoryViewModel);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateTodoCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _todoCategoryService.GetTodoCaterogyByIdAsync(id);
            if (category == null) return NotFound();
            
            var categoryToUpdate = _mapper.Map(dto, category);
            await _todoCategoryService.UpdateTodoCategoryAsync(categoryToUpdate);

            var categoryViewModel = _mapper.Map<TodoCategoryViewModel>(categoryToUpdate);

            return Ok(categoryViewModel);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var isCategoryDeleted = await _todoCategoryService.DeleteTodoCategoryAsync(id);
            if (!isCategoryDeleted) return NotFound();
            return Ok();
        }
    }
}
