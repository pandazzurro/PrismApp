using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismUnityApp1.Services
{
    public interface ILoginService
    {
        Task<MobileServiceUser> LoginFacebookAsync();        
    }

    public interface IUserService
    {
        Task<object> GetDataAsync(MobileServiceUser user, MobileServiceAuthenticationProvider provider);
    }

    public class UserService : IUserService
    {
        private IMobileServiceClient _client;
        public UserService(IMobileServiceClient client)
        {
            _client = client;
        }

        public Task<object> GetDataAsync(MobileServiceUser user, MobileServiceAuthenticationProvider provider)
        {
            var d = new Dictionary<string, string>();
            d.Add("provider", provider.ToString());
            return _client.InvokeApiAsync<object>("Identity", System.Net.Http.HttpMethod.Get, d);
        }
    }
}
