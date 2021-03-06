﻿using EPrint.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EPrint.Services.Facebook
{
    public class Service
    {
        public static async Task<User> GetUserAsync(string accessToken)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=id,name,email&access_token={accessToken}");
            var user = JsonConvert.DeserializeObject<User>(json);
            user.ImageUrl = string.Format("http://graph.facebook.com/{0}/picture?type=large", user.Id);
            return user;
        }
    }
}
