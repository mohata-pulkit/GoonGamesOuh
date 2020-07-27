using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LINQtoCSV;

namespace GoonGamesOuh.Data.Classes
{
	public class UserClass
	{
		[CsvColumn(Name = "User Number", FieldIndex = 1)]
		public int UserNumber { get; set; }
		[CsvColumn(Name = "First Name", FieldIndex = 2)]
		public string FirstName { get; set; }
		[CsvColumn(Name = "Last Name", FieldIndex = 3)]
		public string LastName { get; set; }
		[CsvColumn(Name = "Email ID", FieldIndex = 4)]
		public string EmailID { get; set; }
		[CsvColumn(Name = "Discord Username", FieldIndex = 5)]
		public string DiscordUsername { get; set; }
		[CsvColumn(Name = "Password Hash", FieldIndex = 6)]
		public string PasswordHash { get; set; }
		[CsvColumn(Name = "IP Address", FieldIndex = 7)]
		public string IPAddress { get; set; }
		[CsvColumn(Name = "Current Question", FieldIndex = 8)]
		public int CurrentQuestion { get; set; }
		[CsvColumn(Name = "Current Points", FieldIndex = 9)]
		public int CurrentPoints { get; set; }
		[CsvColumn(Name = "Password Salt", FieldIndex = 10)]
		public string PasswordSalt { get; set; }
	}
}
