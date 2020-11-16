using CleanArchitectureApi.Application.DTOs.Account;
using CleanArchitectureApi.Application.Wrappers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebMvc.Configurations;

namespace WebMvc.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Response<AuthenticationResponse> AccountAuthenticate(AuthenticationRequest authenticationRequest)
        {
            var uri = $"{SiteConfiguration.ApiBaseUrl}{ApiEndPoint.Account_Authenticate}";
            var respose = _httpClient.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(authenticationRequest), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Response<AuthenticationResponse>>(respose);
        }
    }
}
