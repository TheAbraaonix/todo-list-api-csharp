using ToDoListAPI.Entities;

namespace ToDoListAPI.Persistence
{
    public class ToDoDbContext
    {
        public List<ToDo> ToDoList { get; set; }

        public ToDoDbContext()
        {
            ToDoList = new List<ToDo>();
        }
    }
}
