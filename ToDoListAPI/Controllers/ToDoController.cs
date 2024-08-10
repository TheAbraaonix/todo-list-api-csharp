using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Entities;
using ToDoListAPI.Models;
using ToDoListAPI.Services;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/to-do")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _service;

        public ToDoController(IToDoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllToDo")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet()]
        [Route("GetToDoById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            ToDoViewModel toDoViewModel = await _service.GetById(id);

            if (toDoViewModel == null) return NotFound();
            
            return Ok(toDoViewModel);
        }

        [HttpPost]
        [Route("CreateToDo")]
        public async Task<IActionResult> CreateToDo(ToDoInputModel toDo)
        {
            ToDoViewModel toDoViewModel = await _service.Create(toDo);

            if (toDoViewModel == null) return BadRequest();

            return CreatedAtAction(nameof(CreateToDo), new ToDo { Id = toDoViewModel.Id }, toDoViewModel);
        }

        [HttpPut()]
        [Route("UpdateToDo/{id}")]
        public async Task<IActionResult> Update(Guid id, ToDoInputModel input)
        {
            ToDoViewModel toDoViewModel = await _service.Update(id, input);

            if (toDoViewModel == null) return BadRequest();

            return NoContent();
        }

        [HttpDelete()]
        [Route("DeleteToDo/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            ToDoViewModel toDoViewModel = await _service.Delete(id);
            
            if (toDoViewModel == null) return BadRequest();
            
            return NoContent();
        }
    }
}
