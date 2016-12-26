using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Authentication.AppService;
using Microsoft.Azure.Mobile.Server.Config;
using Facebook;
using PrismUnityApp1.Entity;
using Newtonsoft.Json;
using System.Security.Claims;

namespace PrismMobileApp.Controllers
{
    [MobileAppController]
    public class IdentityController : ApiController
    {
        // GET api/Identity
        [Route("api/Identity/{provider}")]
        public async Task<object> Get(string provider)
        {
            string userData = string.Empty;
            
            switch (provider.ToLowerInvariant())
            {
                case "facebook":
                    var credsFb = await User.GetAppServiceIdentityAsync<FacebookCredentials>(Request);
                    return await FacebookDataAsync(credsFb);                    
                case "google":
                    var credsG = await User.GetAppServiceIdentityAsync<GoogleCredentials>(Request);
                    return await GoogleDataAsync(credsG);
                //case "twitter":
                //    creds = await User.GetAppServiceIdentityAsync<TwitterCredentials>(Request);
                //    break;
                //case "microsoftaccount":
                //    creds = await User.GetAppServiceIdentityAsync<MicrosoftAccountCredentials>(Request);
                //    break;
                //case "aad":
                //    creds = await User.GetAppServiceIdentityAsync<AzureActiveDirectoryCredentials>(Request);
                //    break;                
            }

            return userData;
        }

        private async Task<FacebookUser> FacebookDataAsync(FacebookCredentials credentials)
        {
            // Create a query string with the Facebook access token.
            var fbRequestUrl = $"https://graph.facebook.com/me?fields=birthday,email,name&access_token={credentials.AccessToken}";
            // Create an HttpClient request.
            var client = new HttpClient();

            // Request the current user info from Facebook.
            var resp = await client.GetAsync(fbRequestUrl);
            resp.EnsureSuccessStatusCode();

            // Do something here with the Facebook user information.
            var fbInfoString = await resp.Content.ReadAsStringAsync();
            var fbInfo = JsonConvert.DeserializeObject<FacebookUser>(fbInfoString);

            // Carico l'immagine dell'utente
            var fbRequestImageUrl = $"https://graph.facebook.com/me/picture?access_token={credentials.AccessToken}";
            var respImage = await client.GetAsync(fbRequestImageUrl);
            respImage.EnsureSuccessStatusCode();
                        
            fbInfo.profile_image = await respImage.Content.ReadAsByteArrayAsync();
            return fbInfo;
        }

        private async Task<FacebookUser> GoogleDataAsync(GoogleCredentials credential)
        {
            var user = new FacebookUser();
            user.name = credential.UserClaims.Where(x => x.Type == "name").FirstOrDefault().Value;
            user.email = credential.UserClaims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault().Value;
            user.id = credential.UserClaims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            var urlPicture = credential.UserClaims.Where(x => x.Type == "picture").FirstOrDefault().Value;
            HttpClient client = new HttpClient();
            user.profile_image = await client.GetByteArrayAsync(urlPicture);
            return user;            
        }
    }
}
