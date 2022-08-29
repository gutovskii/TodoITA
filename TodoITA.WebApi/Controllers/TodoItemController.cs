using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoITA.WebApi.ViewModels;
using TodoITA.BLL.DTO.TodoItem;
using TodoITA.BLL.Services.Interfaces;
using TodoITA.DataAccess.Entities;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace TodoITA.WebApi.Controllers
{
    [Route("items")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;
        private readonly IMapper _mapper;
        public TodoItemController(ITodoItemService todoItemService, IMapper mapper)
        {
            _todoItemService = todoItemService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(CreateTodoItemDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var todoItemToCreate = _mapper.Map<TodoItem>(dto);
            await _todoItemService.CreateTodoItemAsync(todoItemToCreate);

            var todoItemViewModel = _mapper.Map<TodoItemViewModel>(todoItemToCreate);

            return CreatedAtRoute("GetCategoryById", new { Id = todoItemViewModel.Id }, todoItemViewModel);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateItem(int id, UpdateTodoItemDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var todoItem = await _todoItemService.GetTodoItemByIdAsync(id);
            if (todoItem == null)
                return NotFound();

            var todoItemToUpdate = _mapper.Map(dto, todoItem);
            await _todoItemService.UpdateTodoItemAsync(todoItemToUpdate);

            var todoItemToUpdateViewModel = _mapper.Map<TodoItemViewModel>(todoItemToUpdate);

            return Ok(todoItemToUpdateViewModel);
        } 

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateItemPatch(int id, [FromBody] JsonPatchDocument<TodoItem> patchDocument)
        {
            var todoItemToUpdate = await _todoItemService.GetTodoItemByIdAsync(id);
            if (todoItemToUpdate == null)
                return NotFound();

            await _todoItemService.UpdateTodoItemPatchAsync(todoItemToUpdate, patchDocument);

            var todoItemToUpdateViewModel = _mapper.Map<TodoItemViewModel>(todoItemToUpdate);

            return Ok(todoItemToUpdateViewModel);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var isItemDeleted = await _todoItemService.DeleteTodoItemAsync(id);
            if (!isItemDeleted) return NotFound();
            return Ok();
        }
    }
}
