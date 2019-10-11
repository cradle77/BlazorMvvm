using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BlazorDemo.Components
{
    public class ReactiveComponentBase : ComponentBase
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();

            var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

            var properties = this.GetType().GetProperties(flags)
                .Where(x => x.CanRead)
                .Where(x => x.GetCustomAttributes(typeof(InjectAttribute), inherit: true).Any())
                .Select(x => new { x.Name, Value = x.GetValue(this) as INotifyPropertyChanged })
                .Where(x => x.Value != null);

            Console.WriteLine("OnInitialized running");
            
            foreach (var property in properties)
            {
                Console.WriteLine($"Subscribing to property {property.Name}");
                property.Value.PropertyChanged += (s, e) => this.StateHasChanged();
            }
        }
    }
}
