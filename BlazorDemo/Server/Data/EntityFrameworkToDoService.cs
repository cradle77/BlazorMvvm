using BlazorDemo.Server.Models;
using BlazorDemo.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDemo.Server.Data
{
    internal class EntityFrameworkToDoService : IToDoService
    {
        private DemoContext _context;

        public EntityFrameworkToDoService(DemoContext context)
        {
            _context = context;
        }

        public async Task<ToDoItem> AddAsync(ToDoItem newItem)
        {
            _context.ToDoItems.Add(newItem);

            await _context.SaveChangesAsync();

            return newItem;
        }

        public Task<List<ToDoItem>> GetAllAsync()
        {
            return _context.ToDoItems.ToListAsync();
        }

        public async Task UpdateAsync(ToDoItem item)
        {
            _context.Entry(item).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
