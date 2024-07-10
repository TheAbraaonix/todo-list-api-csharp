using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Entities;
using ToDoListAPI.Models;
using ToDoListAPI.Persistence;
using ToDoListAPI.Services;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/to-do")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoDbContext _context;
        private readonly ToDoService _service;

        public ToDoController(ToDoDbContext context, ToDoService service)
        {
            _context = context;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            ToDoViewModel toDoViewModel = _service.GetById(id);

            if (toDoViewModel == null) return NotFound();
            
            return Ok(toDoViewModel);
        }

        [HttpPost]
        public IActionResult Post(ToDoInputModel input)
        {
            ToDoViewModel toDoViewModel = _service.Create(input);
            
            if (toDoViewModel == null) return BadRequest();
            
            return CreatedAtAction(nameof(Post), new ToDo { Id = toDoViewModel.Id }, toDoViewModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, ToDoInputModel input)
        {
            ToDoViewModel toDoViewModel = _service.Update(id, input);

            if (toDoViewModel == null) return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            ToDoViewModel toDoViewModel = _service.Delete(id);
            
            if (toDoViewModel == null) return BadRequest();
            
            return NoContent();
        }
    }
}
