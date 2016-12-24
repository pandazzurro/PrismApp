using Microsoft.Practices.Unity;
using Microsoft.WindowsAzure.MobileServices;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismUnityApp1.Entity;
using PrismUnityApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrismUnityApp1.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        public DelegateCommand LoginFacebookCommand { get; set; }
        private ILoginService _loginService;
        private INavigationService _navigationService;
        private IUnityContainer _container;
        public LoginPageViewModel(INavigationService navigationService, ILoginService loginService, IUnityContainer container)
        {
            _loginService = loginService;
            _navigationService = navigationService;
            _container = container;
            LoginFacebookCommand = new DelegateCommand(async () => await LoginFacebookAsync());
        }

        public async Task LoginFacebookAsync()
        {
            var user = await _loginService.LoginFacebookAsync();
            FacebookUser fbUser = (FacebookUser)user;
            if (fbUser != null)
            {
                _container.RegisterInstance(typeof(FacebookUser), fbUser, new ContainerControlledLifetimeManager());
                await _navigationService.NavigateAsync("PrismMasterDetailPage/PrismNavigationPage/UserPage");
            }   
        }
    }
}
