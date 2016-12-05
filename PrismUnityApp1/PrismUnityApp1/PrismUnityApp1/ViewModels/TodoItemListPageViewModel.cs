using Prism.Commands;
using Prism.Mvvm;
using PrismUnityApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrismUnityApp1.ViewModels
{
    public class TodoItemListPageViewModel : BindableBase
    {
        private ITodoItemService _todoService;
        public TodoItemListPageViewModel(ITodoItemService todoService)
        {
            _todoService = todoService;
            Task.Run(async () =>
            {
                var result = await _todoService.GetTodos();
            });
        }
    }
}
