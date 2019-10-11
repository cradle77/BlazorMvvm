using BlazorDemo.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.ServerSide.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext (DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
