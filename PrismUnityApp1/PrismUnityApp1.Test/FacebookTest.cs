using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace PrismUnityApp1.Test
{
    public class FacebookTest
    {
        public FacebookTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }



        [Fact]
        public async Task Login()
        {

            var mobileClient = new MobileServiceClient("http://prismmobileapp.azurewebsites.net/");
            string access_token = "EAAW6IRpbYSEBAFYhA2aa517xayT8rUbsMuiUMVf4utHSjekD14I9HrByJTZBMf6KsJGjLHJrRI1OEcVVZBuWITQOvsVkbAcA9ZBvdkNJvwNZA5Mc2FlJ2FC5urglHNcKLgIqVn1YdonJKPtzxPKPXr8gAVov6I7rJ2hZC4cj9ZBgaBEFfERqy3";
            JObject access = new JObject();
            access.Add("acess_token", JToken.Parse(access_token));

            var user = await mobileClient.LoginAsync(MobileServiceAuthenticationProvider.Facebook, access);
            var m = user.MobileServiceAuthenticationToken;

        }
    }
}
