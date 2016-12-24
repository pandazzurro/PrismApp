using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism.Unity;
using Microsoft.Practices.Unity;
using PrismUnityApp1.Services;
using Microsoft.WindowsAzure.MobileServices;
using PrismUnityApp1.Droid.Service;

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
            container.RegisterType<ILoginService, LoginService>(
                new InjectionConstructor(
                    Context, 
                    container.Resolve<IMobileServiceClient>(), 
                    container.Resolve<IUserService>()));
        }
    }    
}

