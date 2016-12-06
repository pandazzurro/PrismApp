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

        public async Task<List<TodoItem>> GetTodos()
        {
            try
            {
                var items = await _client.GetTable<TodoItem>().ReadAsync();
                return items.ToList();
            }
            catch(Exception ex)
            {
                var e = ex;
                throw;
            }
            finally { }
        }

    }

    public class TodoItem 
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Text { get; set; }

        public bool Complete { get; set; }
    }

    public interface ITodoItemService
    {
        Task<List<TodoItem>> GetTodos();
    }
}
