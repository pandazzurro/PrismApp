using Microsoft.WindowsAzure.MobileServices;
using Prism.Unity;
using PrismUnityApp1.Views;
using Microsoft.Practices.Unity;
using PrismUnityApp1.Services;

namespace PrismUnityApp1
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            //NavigationService.NavigateAsync("PrismMasterDetailPage/PrismNavigationPage/MainPage");
            NavigationService.NavigateAsync("LoginPage");
            //NavigationService.NavigateAsync("TodoItemListPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<LoginPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<PrismMasterDetailPage>();
            Container.RegisterTypeForNavigation<PrismNavigationPage>();
            Container.RegisterTypeForNavigation<SecondPage>();
            Container.RegisterTypeForNavigation<TodoItemListPage>();
            Container.RegisterTypeForNavigation<UserPage>();

            var mobileClient = new MobileServiceClient("https://prismmobileapp.azurewebsites.net/");
            Container.RegisterInstance<IMobileServiceClient>(mobileClient);
            Container.RegisterType<IUserService, UserService>();
            Container.RegisterType<ITodoItemService, TodoItemService>();
        }
    }
}
