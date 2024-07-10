using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Entities;
using ToDoListAPI.Models;
using ToDoListAPI.Persistence;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/to-do")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoDbContext _context;
        private readonly IMapper _mapper;

        public ToDoController(ToDoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ToDo> toDos = _context.ToDoList.Where(x => !x.IsDeleted).ToList();
            List<ToDoViewModel> toDosViewModel = _mapper.Map<List<ToDoViewModel>>(toDos);
            
            return Ok(toDosViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            ToDo? toDo = _context.ToDoList.SingleOrDefault(x => x.Id == id);

            if (toDo == null) return NotFound();

            ToDoViewModel toDoViewModel = _mapper.Map<ToDoViewModel>(toDo);
            
            return Ok(toDoViewModel);
        }

        [HttpPost]
        public IActionResult Post(ToDoInputModel input)
        {
            if (input == null) return BadRequest();
            
            ToDo toDo = _mapper.Map<ToDo>(input);
            _context.ToDoList.Add(toDo);
            _context.SaveChanges();
            
            return CreatedAtAction(nameof(Post), new ToDo { Id = toDo.Id }, toDo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, ToDoInputModel input)
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
