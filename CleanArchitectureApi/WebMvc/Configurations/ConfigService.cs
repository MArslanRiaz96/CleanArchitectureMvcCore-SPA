using CleanArchitectureApi.Application.DTOs.Account;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Configurations
{
    public static class ConfigService
    {

        public static void SetAuthentication(AuthenticationResponse authenticationResponse)
        {
            AppContext.Current.Response.Cookies.Append("AspNetCore.Usk", JsonConvert.SerializeObject(authenticationResponse).ToString(), new CookieOptions
            {
                HttpOnly = true
            }) ;
        }

        public static AuthenticationResponse GetAuthentication()
        {
            string cookie = AppContext.Current.Request.Cookies["AspNetCore.Usk"];
            return JsonConvert.DeserializeObject<AuthenticationResponse>(cookie);
        }
    }
}
