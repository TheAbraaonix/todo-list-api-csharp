namespace ToDoListAPI.Models
{
    public class ToDoInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
