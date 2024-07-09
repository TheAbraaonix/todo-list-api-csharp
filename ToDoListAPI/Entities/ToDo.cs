namespace ToDoListAPI.Entities
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }

        public ToDo()
        {
            IsCompleted = false;
            IsDeleted = false;
        }

        public void UpdateStatus()
        {
            IsCompleted = true;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void Update(string name, string description, int priority, bool isCompleted)
        {
            Name = name;
            Description = description;
            Priority = priority;
            IsCompleted = isCompleted;
        }
    }
}
