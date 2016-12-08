using Prism.Commands;
using Prism.Mvvm;
using PrismUnityApp1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PrismUnityApp1.ViewModels
{
    public class TodoItemListPageViewModel : BindableBase
    {
        private ITodoItemService _todoService;
        public ObservableCollection<TodoItem> Todos { get; set; }
        private string _todoName;
        public string TodoName
        {
            get { return _todoName; }
            set { SetProperty(ref _todoName, value); }
        }
        public TodoItem SelectedItem { get; set; }
        public DelegateCommand UpdateCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand InsertCommand { get; set; }
        public TodoItemListPageViewModel(ITodoItemService todoService)
        {
            _todoService = todoService;
            Task.Run(async () =>
            {
                Todos = new ObservableCollection<TodoItem>(await _todoService.GetTodos(0, 10));
            }).Wait();

            UpdateCommand = new DelegateCommand(UpdateAsync);
            DeleteCommand = new DelegateCommand(DeleteAsync);
            InsertCommand = new DelegateCommand(InsertAsync);
        }

        public async void UpdateAsync()
        {
            await _todoService.UpdateTodo(SelectedItem);
        }

        public async void DeleteAsync()
        {
            await _todoService.DeleteTodo(SelectedItem);
        }

        public async void InsertAsync()
        {
            TodoItem newItem = new TodoItem
            {
                Id = Guid.NewGuid().ToString(),
                Text = TodoName,
                Complete = false
            };
            await _todoService.InsertTodo(newItem);
        }
    }
}
