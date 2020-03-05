using System;

namespace BlazorDemo.Client.ViewModels
{
    public class CounterViewModel
    {
        private int currentValue = 0;

        public string Title
        {
            get 
            {
                return currentValue == 0 ? "The counter is currently empty" : $"The value is {currentValue}";
            }
        }

        public void Increment()
        {
            currentValue++;
            Console.WriteLine(this.Title);
        }
    }
}
