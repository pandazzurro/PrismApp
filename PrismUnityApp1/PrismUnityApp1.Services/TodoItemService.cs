using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        private IMobileServiceTable<TodoItem> _table;
        public TodoItemService(IMobileServiceClient client)
        {
            _client = client;
            _table = _client.GetTable<TodoItem>();
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                Converters = { new StringEnumConverter { CamelCaseText = true }, },
                DefaultValueHandling = DefaultValueHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };
        }

        public async Task DeleteTodo(TodoItem item)
        {
            await _table.DeleteAsync(item);
        }

        public async Task<List<TodoItem>> GetTodos(int skip, int take)
        {
            try
            {
                return await _table
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
            await _table.InsertAsync(item);
        }

        public async Task UpdateTodo(TodoItem item)
        {
            await _table.UpdateAsync(item);
        }
    }

    public class TodoItem
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool Complete { get; set; }
        //public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        //public bool Deleted { get; set; } = false;
        //public DateTimeOffset? UpdatedAt { get; set; }
        //public byte[] Version { get; set; }
    }

    public interface ITodoItemService
    {
        Task<List<TodoItem>> GetTodos(int skip, int take);
        Task UpdateTodo(TodoItem item);
        Task DeleteTodo(TodoItem item);
        Task InsertTodo(TodoItem item);
    }
}
