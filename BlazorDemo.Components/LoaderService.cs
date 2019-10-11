using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BlazorDemo.Components
{
    internal class LoaderService : ILoaderService, INotifyPropertyChanged
    {
        private bool _show;
        public bool Show
        {
            get { return _show; }
            set
            {
                if (_show != value)
                {
                    _show = value;

                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Show)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task LoadAsync(Func<Task> load)
        {
            Console.WriteLine("Setting Show to True");
            this.Show = true;

            try
            {
                await load();
            }
            finally
            {
                Console.WriteLine("Setting Show to False");
                this.Show = false;
            }
        }
    }
}
