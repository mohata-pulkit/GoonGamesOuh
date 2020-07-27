using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoonGamesOuh.Models;
using GoonGamesOuh.Data.Readers;
using Microsoft.AspNetCore.Http;

namespace GoonGamesOuh.Controllers
{
    public class LeaderboardController : Controller
    {
        public ActionResult Index()
        {
            Leaderboard leaderboard = new Leaderboard();
            leaderboard.users = UserReader.getAllUsersSorted();
            if (HttpContext.Session.GetString("User Number") == null)
            {
                leaderboard.LoginStatus = false;
            }
            else
            {
                leaderboard.LoginStatus = true;
            }

            return View(leaderboard);
        }
    }
}
