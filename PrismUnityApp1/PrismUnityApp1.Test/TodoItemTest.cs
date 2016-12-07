using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.MobileServices;
using PrismUnityApp1.Services;
using Xunit;

namespace PrismUnityApp1.Test
{
    public class TodoItemTest
    {
        [Fact]
        public void TodoItemTest_GetTodo()
        {
            var mobileClient = new MobileServiceClient("http://prismmobileapp.azurewebsites.net/");
            var service = new TodoItemService(mobileClient);
            var result = service.GetTodos(0,10);
        }
    }
}
