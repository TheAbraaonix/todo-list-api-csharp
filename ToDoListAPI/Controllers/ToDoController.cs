using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Entities;
using ToDoListAPI.Persistence;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/to-do")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public ToDoController(ToDoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ToDos = _context.ToDoList.Where(x => !x.IsDeleted).ToList();
            return Ok(ToDos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var toDo = _context.ToDoList.SingleOrDefault(x => x.Id == id);

            if (toDo == null) return NotFound();

            return Ok(toDo);
        }

        [HttpPost]
        public IActionResult Post(ToDo input)
        {
            if (input == null) return BadRequest();
            
            _context.ToDoList.Add(input);
            return CreatedAtAction(nameof(Post), new ToDo { Id = input.Id }, input);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, ToDo input)
        {
            var toDo = _context.ToDoList.SingleOrDefault(x => x.Id == id);

            if (toDo == null) return BadRequest();

            toDo.Update(input.Name, input.Description, input.Priority, input.IsCompleted);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var toDo = _context.ToDoList.SingleOrDefault(x => x.Id == id);

            if (toDo == null) return BadRequest();

            toDo.Delete();

            return NoContent();
        }
    }
}
