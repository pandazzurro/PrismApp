using Microsoft.WindowsAzure.MobileServices;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
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
        public LoginPageViewModel(INavigationService navigationService, ILoginService loginService)
        {
            _loginService = loginService;
            _navigationService = navigationService;
            LoginFacebookCommand = new DelegateCommand(async () => await LoginFacebookAsync());
        }

        public async Task LoginFacebookAsync()
        {
            var user = await _loginService.LoginFacebookAsync();
            if (string.IsNullOrEmpty(user.UserId))
                await _navigationService.NavigateAsync("PrismMasterDetailPage/PrismNavigationPage/MainPage");
        }
    }
}
