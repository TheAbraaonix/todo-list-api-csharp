using ToDoListAPI.Entities;

namespace ToDoListAPI.Repositories
{
    public interface IToDoRepository
    {
        IEnumerable<ToDo> GetAll();
        ToDo GetById(Guid id);
        ToDo Create(ToDo entity);
        ToDo Update(ToDo entity);
        ToDo Delete(ToDo entity);
    }
}
