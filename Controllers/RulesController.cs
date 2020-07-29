using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GoonGamesOuh.Models;
using GoonGamesOuh.Data.Readers;

namespace GoonGamesOuh.Controllers
{
	public class RulesController : Controller
	{
		public ViewResult Index()
		{
			GoonGamesOuh.Controllers.playController.Solution.ConfirmationMessage = null;
            GoonGamesOuh.Controllers.ShopController.shop.ConfirmationMessage = null;
			GoonGamesOuh.Controllers.UserController.myUser.ConfirmationMessage = null;
			Rules ruler = new Rules();
			List<string> rules = new List<string>();
			int i = 0;
			while(i < RulesReader.getRuleMax())
			{
				rules.Add(RulesReader.getRule(i));
				i++;
			}
			ruler.rules = rules.ToArray();
			if (HttpContext.Session.GetString("User Number") == null)
			{
				ruler.LoginStatus = false;
			}
			else
			{
				ruler.LoginStatus = true;
			}

			return View(ruler);
		}
	}
}
