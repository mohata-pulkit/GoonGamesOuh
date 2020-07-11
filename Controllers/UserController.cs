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

namespace GoonGamesOuh.Controllers
{
	public class UserController : Controller
	{
		public ViewResult Index()
		{
			return View();
		}
		[HttpPost]
		public RedirectToActionResult Register(User user)
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

			UserWriter.addUser(writeUser);
			return RedirectToAction("Index");
		}
	}
}
