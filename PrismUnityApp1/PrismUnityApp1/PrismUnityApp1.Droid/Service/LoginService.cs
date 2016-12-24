using Android.Content;
using Microsoft.WindowsAzure.MobileServices;
using PrismUnityApp1.Entity;
using PrismUnityApp1.Services;
using System.Threading.Tasks;

namespace PrismUnityApp1.Droid.Service
{
    public class LoginService : ILoginService
    {
        private IMobileServiceClient _client;
        private Context _context;
        private IUserService _userService;

        public LoginService(Context context, IMobileServiceClient client, IUserService userService)
        {
            _client = client;
            _context = context;
            _userService = userService;
        }

        public async Task<object> LoginFacebookAsync()
        {
            MobileServiceUser user = await _client.LoginAsync(_context, MobileServiceAuthenticationProvider.Facebook);
            var facebookData = await _userService.GetDataAsync(user, MobileServiceAuthenticationProvider.Facebook);
            return facebookData;
        }
    }
}