using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoonGamesOuh.Models;

namespace GoonGamesOuh.Controllers
{
    public class playController : Controller
    {
        public ViewResult Question()
        {
            play Question = new play() { Name = "Hello", Id = 1 };
            return View(Question);
        }
    }
}
