using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Shared
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
