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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            ToDoViewModel toDoViewModel = await _service.GetById(id);

            if (toDoViewModel == null) return NotFound();
            
            return Ok(toDoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ToDoInputModel input)
        {
            ToDoViewModel toDoViewModel = await _service.Create(input);
            
            if (toDoViewModel == null) return BadRequest();
            
            return CreatedAtAction(nameof(Post), new ToDo { Id = toDoViewModel.Id }, toDoViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ToDoInputModel input)
        {
            ToDoViewModel toDoViewModel = await _service.Update(id, input);

            if (toDoViewModel == null) return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            ToDoViewModel toDoViewModel = await _service.Delete(id);
            
            if (toDoViewModel == null) return BadRequest();
            
            return NoContent();
        }
    }
}
