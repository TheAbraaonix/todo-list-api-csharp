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
            List<ToDo> toDos = _context.ToDoList.Where(x => !x.IsDeleted).ToList();
            return Ok(toDos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            ToDo? toDo = _context.ToDoList.SingleOrDefault(x => x.Id == id);

            if (toDo == null) return NotFound();

            return Ok(toDo);
        }

        [HttpPost]
        public IActionResult Post(ToDo input)
        {
            if (input == null) return BadRequest();
            
            _context.ToDoList.Add(input);
            _context.SaveChanges();
            
            return CreatedAtAction(nameof(Post), new ToDo { Id = input.Id }, input);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, ToDo input)
        {
            ToDo? toDo = _context.ToDoList.SingleOrDefault(x => x.Id == id);

            if (toDo == null) return BadRequest();

            toDo.Update(input.Name, input.Description, input.Priority, input.IsCompleted);
            _context.ToDoList.Update(toDo);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            ToDo? toDo = _context.ToDoList.SingleOrDefault(x => x.Id == id);

            if (toDo == null) return BadRequest();

            toDo.Delete();
            _context.SaveChanges();

            return NoContent();
        }
    }
}
