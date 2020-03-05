using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BlazorDemo.Components
{
    public interface ILoaderService : INotifyPropertyChanged
    {
        Task LoadAsync(Func<Task> load);
        bool Show { get; }
    }
}
