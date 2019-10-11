using BlazorDemo.Components;
using BlazorDemo.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Client.ViewModels
{
    public class ToDoItemsViewModel
    {
        private IToDoService _toDoItems;
        private ILoaderService _loader;

        public ToDoItemsViewModel(IToDoService toDoItems, ILoaderService loader)
        {
            _toDoItems = toDoItems;
            _loader = loader;
        }

        public List<ToDoItem> Items { get; set; } = new List<ToDoItem>();

        public IEnumerable<ToDoItem> OutstandingItems => this.Items.Where(x => !x.IsCompleted);

        public int ItemsLeft => this.OutstandingItems.Count();

        public bool IsLoaded { get; set; } = false;

        public async Task LoadAsync()
        {
            await _loader.LoadAsync(async () => 
            {
                this.Items = await _toDoItems.GetAllAsync();

                this.IsLoaded = true;
            });
        }

        public async Task CompleteItemAsync(ToDoItem item)
        {
            item.IsCompleted = true;

            await _toDoItems.UpdateAsync(item);
        }

        public bool CanAddNewItem => !string.IsNullOrWhiteSpace(this.NewItem?.Description);

        public ToDoItem NewItem { get; private set; } = new ToDoItem();

        public async Task AddNewItemAsync()
        {
            var result = await _toDoItems.AddAsync(this.NewItem);

            this.Items.Add(result);

            this.NewItem = new ToDoItem();
        }
    }
}
