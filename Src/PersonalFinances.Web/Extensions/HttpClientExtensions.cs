using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PersonalFinances.Web.Extensions
{
    public static class HttpClientExtensions
    {
        public static void SetToken(this HttpClient httpClient, string token)
        {
            var stoken = token.Split("Bearer ");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", stoken[1]);
        }
    }
}