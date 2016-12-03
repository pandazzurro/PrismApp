using Prism.Unity;
using PrismUnityApp1.Views;

namespace PrismUnityApp1
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("PrismMasterDetailPage/PrismNavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<PrismMasterDetailPage>();
            Container.RegisterTypeForNavigation<PrismNavigationPage>();
            Container.RegisterTypeForNavigation<SecondPage>();
        }
    }
}
