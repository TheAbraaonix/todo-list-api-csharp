using ToDoListAPI.Entities;

namespace ToDoListAPI.Repositories
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDo>> GetAllAsync();
        Task<ToDo> GetByIdAsync(Guid id);
        Task<ToDo> CreateAsync(ToDo entity);
        Task<ToDo> UpdateAsync(ToDo entity);
        Task<ToDo> DeleteAsync(ToDo entity);
    }
}
