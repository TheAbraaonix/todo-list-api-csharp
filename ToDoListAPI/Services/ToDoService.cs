using AutoMapper;
using ToDoListAPI.Entities;
using ToDoListAPI.Models;
using ToDoListAPI.Persistence;

namespace ToDoListAPI.Services
{
    public class ToDoService
    {
        private readonly ToDoDbContext _context;
        private readonly IMapper _mapper;

        public ToDoService(ToDoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ToDoViewModel> GetAll()
        {
            List<ToDoViewModel> toDos = _mapper.Map<List<ToDoViewModel>>(_context.ToDoList.Where(x => !x.IsDeleted));
            return toDos;
        }

        public ToDoViewModel GetById(Guid id)
        {
            ToDo? toDo = _context.ToDoList.SingleOrDefault(x => x.Id == id);

            if (toDo == null) return null;

            return _mapper.Map<ToDoViewModel>(toDo);
        }

        public ToDoViewModel Create(ToDoInputModel input)
        {
            if (input == null) return null;

            ToDo toDo = _mapper.Map<ToDo>(input);
            _context.Add(toDo);
            _context.SaveChanges();

            return _mapper.Map<ToDoViewModel>(toDo);
        }

        public ToDoViewModel Update(Guid id, ToDoInputModel input)
        {
            ToDo? toDo = _context.ToDoList.SingleOrDefault(x => x.Id == id);

            if (toDo == null) return null;

            toDo.Update(input.Name, input.Description, input.Priority, input.IsCompleted);
            _context.ToDoList.Update(toDo);
            _context.SaveChanges();

            return _mapper.Map<ToDoViewModel>(toDo);
        }

        public ToDoViewModel Delete(Guid id)
        {
            ToDo? toDo = _context.ToDoList.SingleOrDefault(x => x.Id == id);

            if (toDo == null) return null;

            toDo.Delete();
            _context.SaveChanges();

            return _mapper.Map<ToDoViewModel>(toDo);
        }
    }
}
