using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismUnityApp1.Services
{
    public class TodoItemService : ITodoItemService
    {
        public IMobileServiceClient _client;
        public TodoItemService(IMobileServiceClient client)
        {
            _client = client;
        }

        public async Task DeleteTodo(TodoItem item)
        {
            await _client.GetTable<TodoItem>().DeleteAsync(item);
        }

        public async Task<List<TodoItem>> GetTodos(int skip, int take)
        {
            try
            {
                return await _client.GetTable<TodoItem>()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
            }
            catch(Exception ex)
            {
                var e = ex;
                throw;
            }
            finally { }
        }

        public async Task InsertTodo(TodoItem item)
        {
            try
            {
                await _client.GetTable<TodoItem>().InsertAsync(item);
            }
            catch(Exception ex)
            {
                var e = ex;
            }
        }

        public async Task UpdateTodo(TodoItem item)
        {
            await _client.GetTable<TodoItem>().UpdateAsync(item);
        }
    }

    public class TodoItem 
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("complete")]
        public bool Complete { get; set; }
    }

    public interface ITodoItemService
    {
        Task<List<TodoItem>> GetTodos(int skip, int take);
        Task UpdateTodo(TodoItem item);
        Task DeleteTodo(TodoItem item);
        Task InsertTodo(TodoItem item);
    }
}
