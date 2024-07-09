namespace ToDoListAPI.Entities
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }

        public ToDo()
        {
            IsCompleted = false;
        }

        public void UpdateStatus()
        {
            IsCompleted = true;
        }
    }
}
