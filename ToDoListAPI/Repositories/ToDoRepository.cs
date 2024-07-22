using ToDoListAPI.Entities;
using ToDoListAPI.Persistence;

namespace ToDoListAPI.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoDbContext _context;

        public ToDoRepository(ToDoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ToDo> GetAll()
        {
            IEnumerable<ToDo> toDos = _context.ToDoList.ToList().Where(t => !t.IsDeleted);
            return toDos;
        }

        public ToDo GetById(Guid id)
        {
            ToDo? toDo = _context.ToDoList.Where(t => t.Id == id).SingleOrDefault();
            return toDo;
        }

        public ToDo Create(ToDo entity)
        {
            _context.ToDoList.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public ToDo Update(ToDo entity)
        {
            _context.Set<ToDo>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public ToDo Delete(ToDo entity)
        {
            entity.Delete();
            _context.SaveChanges();
            return entity;
        } 
    }
}
