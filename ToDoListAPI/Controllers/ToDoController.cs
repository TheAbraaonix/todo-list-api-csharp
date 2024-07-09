using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Entities;
using ToDoListAPI.Persistence;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/to-do")]
    public class ToDoController : Controller
    {
        private readonly ToDoDbContext _context;

        public ToDoController(ToDoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ToDos = _context.ToDoList.Where(x => !x.IsCompleted).ToList();
            return Ok(ToDos);
        }

        [HttpPost]
        public IActionResult Post(ToDo toDo)
        {
            if (toDo == null) return BadRequest();
            
            _context.ToDoList.Add(toDo);
            return CreatedAtAction(nameof(Post), new ToDo { Id = toDo.Id }, toDo);
        }
    }
}
