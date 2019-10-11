using System;
using System.ComponentModel;

namespace BlazorDemo.Client.ViewModels
{
    public class CounterViewModel : INotifyPropertyChanged
    {
        private int currentValue = 0;

        public string Title
        {
            get
            {
                return currentValue == 0 ? "The counter is currently empty" : $"The value is {currentValue}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Increment()
        {
            currentValue++;

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));

            Console.WriteLine(this.Title);
        }
    }
}
