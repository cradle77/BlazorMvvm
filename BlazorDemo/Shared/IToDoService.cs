using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDemo.Shared
{
    public interface IToDoService
    {
        Task<List<ToDoItem>> GetAllAsync();

        Task<ToDoItem> AddAsync(ToDoItem newItem);

        Task UpdateAsync(ToDoItem item);
    }
}
