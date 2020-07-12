using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoonGamesOuh.Models;
using GoonGamesOuh.Data.Readers;

namespace GoonGamesOuh.Controllers
{
    public class LeaderboardController : Controller
    {
        public ActionResult Index()
        {
            Leaderboard leaderboard = new Leaderboard();
            leaderboard.users = UserReader.getAllUsersSorted();

            return View(leaderboard);
        }
    }
}
