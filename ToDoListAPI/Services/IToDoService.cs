using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoViewModel>> GetAll();
        Task<ToDoViewModel> GetById(Guid id);
        Task<ToDoViewModel> Create(ToDoInputModel model);
        Task<ToDoViewModel> Update(Guid id, ToDoInputModel model);
        Task<ToDoViewModel> Delete(Guid id);
    }
}
