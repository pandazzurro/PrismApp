using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismUnityApp1.Services
{
    public class LoginService : ILoginService
    {
        private IMobileServiceClient _client;
        public LoginService(IMobileServiceClient client)
        {
            _client = client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        /// <remarks>
        ///    The token object needs to be formatted depending on the specific provider. These
        ///    are some examples of formats based on the providers: MicrosoftAccount {"authenticationToken":"<the_authentication_token>"}
        ///    Facebook {"access_token":"<the_access_token>"} Google {"access_token":"<the_access_token>"}
        ///</remarks>
        public async Task<MobileServiceUser> LoginFacebookAsync()
        {
            try
            {
                //var at = new AccessToken { access_token = "8c67e507e84309aafccd2523505d3095" };
                JObject accessToken = new JObject();
                accessToken["access_token"] = "8c67e507e84309aafccd2523505d3095";
                return await _client.LoginAsync(MobileServiceAuthenticationProvider.Facebook, accessToken);
            }
            catch(Exception ex)
            {
                var e = ex;
                throw new Exception();
            }
        }
    }

    public interface ILoginService
    {
        Task<MobileServiceUser> LoginFacebookAsync();
    }

    public class AccessToken
    {
        public string access_token { get; set; }
    }
}
