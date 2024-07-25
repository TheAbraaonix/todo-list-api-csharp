using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<ToDo>> GetAllAsync()
        {
            IEnumerable<ToDo> toDos = await _context.ToDoList.Where(t => !t.IsDeleted).ToListAsync();
            return toDos;
        }

        public async Task<ToDo> GetByIdAsync(Guid id)
        {
            ToDo? toDo = await _context.ToDoList.Where(t => t.Id == id).SingleOrDefaultAsync();
            return toDo;
        }

        public async Task<ToDo> CreateAsync(ToDo entity)
        {
            _context.ToDoList.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ToDo> UpdateAsync(ToDo entity)
        {
            _context.Set<ToDo>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ToDo> DeleteAsync(ToDo entity)
        {
            entity.Delete();
            await _context.SaveChangesAsync();
            return entity;
        } 
    }
}
