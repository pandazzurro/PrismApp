using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using PrismUnityApp1.Entity;
using PrismUnityApp1.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrismUnityApp1.ViewModels
{
    public class UserPageViewModel : BindableBase
    {
        private ILoginService _loginService;
        private IUnityContainer _container;
        public string Username { get; set; }
        public DateTime DataNascita { get; set; }
        public string Email { get; set; }
        public ImageSource FotoProfilo { get; set; }
        public DelegateCommand LogoutCommand { get; set; }
        public UserPageViewModel(FacebookUser user, ILoginService loginService, IUnityContainer container)
        {
            _loginService = loginService;
            _container = container;

            if (user != null && !string.IsNullOrEmpty(user.id))
            {
                Username = user.name;
                DataNascita = user.birthday;
                Email = user.email;
                LogoutCommand = new DelegateCommand(LogoutAsync);
                FotoProfilo = ImageSource.FromStream(() => new MemoryStream(user.profile_image));
            }
        }

        private async void LogoutAsync()
        {
            await _loginService.LogoutAsync();
            if (_container.IsRegistered(typeof(FacebookUser)))
            {
                foreach (var registration in _container.Registrations.Where(p => p.RegisteredType == typeof(FacebookUser)
                    && p.LifetimeManagerType == typeof(ContainerControlledLifetimeManager)))
                {
                    registration.LifetimeManager.RemoveValue();
                }
            }
                
        }
    }
}
