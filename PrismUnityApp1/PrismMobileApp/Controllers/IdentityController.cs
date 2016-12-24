﻿using System;
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

namespace PrismMobileApp.Controllers
{
    [MobileAppController]
    public class IdentityController : ApiController
    {
        // GET api/Identity
        [Route("api/Identity/{provider}")]
        public async Task<string> Get(string provider)
        {
            string userData = string.Empty;
            
            switch (provider.ToLowerInvariant())
            {
                case "facebook":
                    var creds = await User.GetAppServiceIdentityAsync<FacebookCredentials>(Request);
                    return await FacebookDataAsync(creds);                    
                //case "google":
                //    creds = await User.GetAppServiceIdentityAsync<GoogleCredentials>(Request);
                //    break;
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

        private async Task<string> FacebookDataAsync(FacebookCredentials credentials)
        {
            // Create a query string with the Facebook access token.
            var fbRequestUrl = "https://graph.facebook.com/me?fields=birthday,email,name&access_token=" + credentials.AccessToken;

            // Create an HttpClient request.
            var client = new HttpClient();

            // Request the current user info from Facebook.
            var resp = await client.GetAsync(fbRequestUrl);
            resp.EnsureSuccessStatusCode();

            // Do something here with the Facebook user information.
            var fbInfo = await resp.Content.ReadAsStringAsync();
            return fbInfo;
        }
    }
}
