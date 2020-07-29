using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GoonGamesOuh.Models;
using Microsoft.AspNetCore.Http;

namespace GoonGamesOuh.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            GoonGamesOuh.Controllers.playController.Solution.ConfirmationMessage = "";
            GoonGamesOuh.Controllers.ShopController.shop.ConfirmationMessage = "";
            GoonGamesOuh.Controllers.UserController.myUser.ConfirmationMessage = "";
            Home home = new Home();
            home.Name = HttpContext.Session.GetString("Name");
            if (HttpContext.Session.GetString("User Number") == null)
            {
                home.LoginStatus = false;
            }
            else
            {
                home.LoginStatus = true;
            }
            return View(home);
        }
    }
}
