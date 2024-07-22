using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    public interface IToDoService
    {
        IEnumerable<ToDoViewModel> GetAll();
        ToDoViewModel GetById(Guid id);
        ToDoViewModel Create(ToDoInputModel model);
        ToDoViewModel Update(Guid id, ToDoInputModel model);
        ToDoViewModel Delete(Guid id);
    }
}
