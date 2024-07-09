using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Entities;

namespace ToDoListAPI.Persistence
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
            
        }

        public DbSet<ToDo> ToDoList { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ToDo>(e =>
            {
                e.HasKey(todo => todo.Id);
                
                e.Property(todo => todo.Name)
                    .IsRequired(true)
                    .HasMaxLength(100);
                
                e.Property(todo => todo.Description)
                    .IsRequired(true)
                    .HasMaxLength(200);
                
                e.Property(todo => todo.Priority)
                    .IsRequired(true)
                    .HasAnnotation("Min", 1)
                    .HasAnnotation("Max", 3);
            });
        }
    }
}
