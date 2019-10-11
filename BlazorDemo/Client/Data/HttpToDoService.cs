using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorDemo.Shared;
using Microsoft.AspNetCore.Components;
using Polly;

namespace BlazorDemo.Client.Data
{
    public class HttpToDoService : IToDoService
    {
        private HttpClient _http;
        private IAsyncPolicy _policy;

        public HttpToDoService(HttpClient http, IAsyncPolicy policy)
        {
            _http = http;
            _policy = policy;
        }

        public async Task<ToDoItem> AddAsync(ToDoItem newItem)
        {
            var item = await _http.PostJsonAsync<ToDoItem>("ToDoItems", newItem);

            return item;
        }

        public async Task<List<ToDoItem>> GetAllAsync()
        {
            return await _policy.ExecuteAsync(() => _http.GetJsonAsync<List<ToDoItem>>("ToDoItems/problematic"));
        }

        public async Task UpdateAsync(ToDoItem item)
        {
            await _http.PutJsonAsync($"ToDoItems/{item.Id}", item);
        }
    }
}
