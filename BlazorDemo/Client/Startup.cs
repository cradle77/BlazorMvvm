using BlazorDemo.Client.Data;
using BlazorDemo.Client.ViewModels;
using BlazorDemo.Components;
using BlazorDemo.Shared;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;

namespace BlazorDemo.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<CounterViewModel>();
            services.AddTransient<IToDoService, HttpToDoService>();
            services.AddTransient<ToDoItemsViewModel>();

            var policy = Policy.Handle<Exception>()
                .RetryAsync(10, (ex, count) =>
                {
                    Console.WriteLine($"Polly: error during call, retry n. {count}");
                });
            services.AddScoped<IAsyncPolicy>(provider => policy);

            services.AddLoader();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
