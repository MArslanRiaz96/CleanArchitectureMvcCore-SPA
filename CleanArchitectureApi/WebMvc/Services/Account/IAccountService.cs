using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureApi.Application.DTOs.Account;
using CleanArchitectureApi.Application.Wrappers;

namespace WebMvc.Services.Account
{
    public interface IAccountService
    {
        Response<AuthenticationResponse> AccountAuthenticate(AuthenticationRequest authenticationRequest);
    }
}
