using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GoonGamesOuh.Models
{
	public class User
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		[Required(ErrorMessage = "Email ID is Required")]
		public string EmailID { get; set; }
		[Required(ErrorMessage = "Discord Username is Required")]
		public string DiscordUsername { get; set; }
		[Required(ErrorMessage = "Password is Required")]
		public string Password { get; set; }
		public byte[] PasswordSalt { get; set; }
		public string PasswordHash { get; set; }
		public string IPAddress { get; set; }
		public string ConfirmationMessage { get; set; }
	}
}
