using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using GoonGamesOuh.Models;
using GoonGamesOuh.Data.Readers;
using GoonGamesOuh.Data.Classes;
using System.ComponentModel;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata.Ecma335;

namespace GoonGamesOuh.Controllers
{
	public class UserController : Controller
	{
		public static User myUser = new User();
		public ViewResult Index()
		{
			GoonGamesOuh.Controllers.playController.Solution.ConfirmationMessage = null;
			GoonGamesOuh.Controllers.ShopController.shop.ConfirmationMessage = null;
			if (HttpContext.Session.GetString("User Number") == null)
			{
				myUser.LoginStatus = false;
			}
			else
			{
				myUser.LoginStatus = true;
			}
			return View(myUser);
		}
		[HttpPost]
		public RedirectToActionResult Register(User user)
		{
			if (user.Password == null || user.EmailID == null || user.DiscordUsername == null)
			{
				myUser.ConfirmationMessage = "Please Enter All Fields";
				return RedirectToAction("Index");
			}
			else
			{
				foreach(UserClass n in UserReader.getAllUsersSorted())
				{
					if (user.EmailID == n.EmailID || user.DiscordUsername == n.DiscordUsername)
					{
						myUser.ConfirmationMessage = "An account with these details is already registered";
						return RedirectToAction("Index");
					}
				}
			}
			{
				bool validEmail = false;
				bool validDiscord = false;

				if (user.EmailID.Contains('@'))
                {
					validEmail = true;
                }

                if (user.DiscordUsername.Contains('#'))
                {
					validDiscord = true;
                }

				if(validDiscord && validEmail)
                {
					byte[] salt = new byte[128 / 8];
					using (var rng = RandomNumberGenerator.Create())
					{
						rng.GetBytes(salt);
					}
					user.PasswordSalt = salt;

					string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
					password: user.Password,
					salt: salt,
					prf: KeyDerivationPrf.HMACSHA256,
					iterationCount: 10000,
					numBytesRequested: 256 / 8));

					user.PasswordHash = hashed;

					string salty = BitConverter.ToString(salt);

					UserClass writeUser = new UserClass();

					writeUser.FirstName = user.FirstName;
					writeUser.LastName = user.LastName;
					writeUser.EmailID = user.EmailID;
					writeUser.DiscordUsername = user.DiscordUsername;
					writeUser.PasswordHash = user.PasswordHash;
					writeUser.PasswordSalt = salty;
					writeUser.CurrentQuestion = 1;
					writeUser.CurrentPoints = 0;
					writeUser.SkipCard = false;

					UserWriter.addUser(writeUser);

					myUser.ConfirmationMessage = "Successfully Registered, Please Log In";

					return RedirectToAction("Index");
				}
                else
                {
					myUser.ConfirmationMessage = "Please Enter Valid Credentials";
					return RedirectToAction("Index");
				}
			}
		}
		[HttpPost]
		public ActionResult Login(User user)
		{
			if(user.Password == null || user.EmailID == null)
			{
				myUser.ConfirmationMessage = "Please Enter Valid Credentials";
				return RedirectToAction("Index");
			}
			else
			{
				foreach(UserClass n in UserReader.getAllUsersSorted())
				{
					string[] decodeSaltString = n.PasswordSalt.Split('-');
					List<int> decodeSaltInt = new List<int>();
					foreach(string hex in decodeSaltString)
					{
						int intValue = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
						decodeSaltInt.Add(intValue);
					}
					byte[] decodeSalt = new byte[128 / 8];
					for(int i = 0; i < decodeSaltInt.Count; i++)
					{
						decodeSalt[i] = Convert.ToByte(decodeSaltInt[i]);
					}
					string password = Convert.ToBase64String(KeyDerivation.Pbkdf2(
					password: user.Password,
					salt: decodeSalt,
					prf: KeyDerivationPrf.HMACSHA256,
					iterationCount: 10000,
					numBytesRequested: 256 / 8));
					if (user.EmailID == n.EmailID && password == n.PasswordHash)
					{
						myUser.ConfirmationMessage = "Successfully Logged In. You may now continue to the questions";
						HttpContext.Session.SetInt32("User Number", n.UserNumber);
						HttpContext.Session.SetString("Name", n.FirstName + " " + n.LastName);

						n.IPAddress = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.GetValue(1).ToString();

						return RedirectToAction("Index","Home");
					}
				}
				myUser.ConfirmationMessage = "Could not find a User with these credentials. Try registering on the site";
				return RedirectToAction("Index");
			}
		}
		public RedirectToActionResult Logout()
		{
			HttpContext.Session.Remove("User Number");
			HttpContext.Session.Remove("Name");

			return RedirectToAction("Index", "Home");
		}
	}
}
