using CleanArchitectureApi.Application.DTOs.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Configurations;
using WebMvc.Services.Account;
using CleanArchitectureApi.Application.Enums;
namespace WebMvc.Controllers
{
    public class AccountController :  Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Authenticate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthenticationRequest authenticationRequest)
        {
            
            if (ModelState.IsValid)
            {
                var result =  _accountService.AccountAuthenticate(authenticationRequest);
                ConfigService.SetAuthentication(result.Data);
                if (result.Data.IsVerified)
                {
                    ConfigService.SetAuthentication(result.Data);
                    return RedirectToAction("Dashboardd", "Dashboard");
                }
                else
                {
                    TempData["ErrorMessage"] = "UserName either Password is Incorrect";
                    return View(authenticationRequest);
                }
            }
            TempData["SuccessMessage"] = "Successfully Loged In";
            return View(authenticationRequest);
        }
        
    }
}
