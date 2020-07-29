using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoonGamesOuh.Data.Readers;
using Microsoft.AspNetCore.Http;
using GoonGamesOuh.Models;

namespace GoonGamesOuh.Controllers
{
	public class ShopController : Controller
	{
		public static Shop shop = new Shop();
		public ViewResult Index()
		{
			GoonGamesOuh.Controllers.playController.Solution.ConfirmationMessage = null;
			GoonGamesOuh.Controllers.UserController.myUser.ConfirmationMessage = null;
			if (HttpContext.Session.GetString("User Number") == null)
			{
				shop.LoginStatus = false;
			}
			else
			{
				shop.LoginStatus = true;
			}
			return View(shop);
		}
		public RedirectToActionResult AddSkipCard()
		{
			int i = Convert.ToInt32(HttpContext.Session.GetInt32("User Number"));
			if(shop.LoginStatus == false)
            {
				shop.ConfirmationMessage = "I dont know how you were able to get here without logging in, but please do so before using the shop";
				return RedirectToAction("Index", "Shop");
            }
			else if (UserReader.getUser(i).CurrentPoints < 600)
            {
				shop.ConfirmationMessage = "Sorry, you dont seem to have enough points for that purchase";
				return RedirectToAction("Index", "Shop");
			}
			else if (UserReader.getUser(i).SkipCard == true)
            {
				shop.ConfirmationMessage = "You already have a skip card retard!";
				return RedirectToAction("Index", "Shop");
			}
            else
            {
				UserWriter.addSkipCard(i);
				shop.ConfirmationMessage = "";
				return RedirectToAction("question", "play");
			}
		}
		public RedirectToActionResult No()
        {
			shop.ConfirmationMessage = "";
			return RedirectToAction("question", "play");
        }
	}
}
