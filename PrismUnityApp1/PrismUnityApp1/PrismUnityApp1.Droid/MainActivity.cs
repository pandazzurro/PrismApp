using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Prism.Unity;
using Microsoft.Practices.Unity;
using PrismUnityApp1.Services;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Security.Claims;

namespace PrismUnityApp1.Droid
{
    [Activity(Label = "PrismUnityApp1", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;
            
            base.OnCreate(bundle);
            
            global::Xamarin.Forms.Forms.Init(this, bundle);            
            LoadApplication(new App(new AndroidInitializer(this)));

            var x = typeof(Xamarin.Forms.Themes.DarkThemeResources);
            x = typeof(Xamarin.Forms.Themes.Android.UnderlineEffect);
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public static Android.Content.Context Context { get; set; }

        public AndroidInitializer(Android.Content.Context context)
        {
            Context = context;
        }
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ILoginService, LoginService>(new InjectionConstructor(Context, container.Resolve<IMobileServiceClient>(), container.Resolve<IUserService>()));
        }
    }

    public class LoginService : ILoginService
    {
        private IMobileServiceClient _client;
        private Android.Content.Context _context;
        private IUserService _userService;

        public LoginService(Android.Content.Context context, IMobileServiceClient client, IUserService userService)
        {
            _client = client;
            _context = context;
            _userService = userService;
        }

        public async Task<MobileServiceUser> LoginFacebookAsync()
        {
            MobileServiceUser user = await _client.LoginAsync(_context, MobileServiceAuthenticationProvider.Facebook);
            var o = await _userService.GetDataAsync(user, MobileServiceAuthenticationProvider.Facebook);
            return user;
        }
    }
}

