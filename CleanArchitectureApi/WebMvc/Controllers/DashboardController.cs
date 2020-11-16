using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Configurations;

namespace WebMvc.Controllers
{
    public class DashboardController : Controller
    {
        public async Task<IActionResult> Dashboardd()
        {
            var response=ConfigService.GetAuthentication();

            TempData["Roles"] = response.Roles.FirstOrDefault();

            if (response.Roles.FirstOrDefault() == "Basic")
            {
                return View("DashboardBasic");
            }
            else
            {
                return View("DashboardAdmin");
            }
             
            
        }
    }
}
