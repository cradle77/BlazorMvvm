using BlazorDemo.Client.Data;
using BlazorDemo.Client.ViewModels;
using BlazorDemo.Components;
using BlazorDemo.Shared;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Threading.Tasks;

namespace BlazorDemo.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static WebAssemblyHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault();

            builder.Services.AddScoped<CounterViewModel>();
            builder.Services.AddTransient<IToDoService, HttpToDoService>();
            builder.Services.AddTransient<ToDoItemsViewModel>();
            builder.Services.AddLoader();
            var policy = Policy.Handle<Exception>()
                .RetryAsync(10, (ex, count) =>
                {
                    Console.WriteLine($"Polly: error during call, retry n. {count}");
                });
            builder.Services.AddScoped<IAsyncPolicy>(provider => policy);

            builder.RootComponents.Add<App>("app");

            return builder;
        }
        
    }
}
