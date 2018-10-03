using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }
        
         public DbSet<Todo> Todo { get; set; }
    }
}