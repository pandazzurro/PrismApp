using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using PrismUnityApp1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PrismUnityApp1.Services
{
    public interface ILoginService
    {
        Task<object> LoginFacebookAsync();        
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

        public async Task<object> GetDataAsync(MobileServiceUser user, MobileServiceAuthenticationProvider provider)
        {
            var providerParameter = new Dictionary<string, string>();
            providerParameter.Add("provider", provider.ToString());
            FacebookUser apiResult = await _client.InvokeApiAsync<FacebookUser>("Identity", HttpMethod.Get, providerParameter);
            return apiResult;
        }
    }
}
