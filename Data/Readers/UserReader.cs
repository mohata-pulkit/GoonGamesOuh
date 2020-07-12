using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoonGamesOuh.Data.Classes;
using GoonGamesOuh.Models;
using LINQtoCSV;

namespace GoonGamesOuh.Data.Readers
{
    public class UserReader
    {
        public static UserClass getUser(int input)
        {
			CsvFileDescription inputFileDescription = new CsvFileDescription
			{
				SeparatorChar = ',',
				FirstLineHasColumnNames = true
			};
			CsvContext cc = new CsvContext();
			IEnumerable<UserClass> users = cc.Read<UserClass>("Data/Databases/UserDatabase.csv", inputFileDescription);
			foreach (UserClass user in users)
			{
				if (user.UserNumber == input)
				{
					return user;
				}
			}
			return null;
		}
		public static int getMaxUsers()
        {
			CsvFileDescription inputFileDescription = new CsvFileDescription
			{
				SeparatorChar = ',',
				FirstLineHasColumnNames = true
			};
			CsvContext cc = new CsvContext();
			IEnumerable<UserClass> users = cc.Read<UserClass>("Data/Databases/UserDatabase.csv", inputFileDescription);
			int solution = users.Count();

			return solution;
		}
		public static List<UserClass> getAllUsersSorted()
		{
			CsvFileDescription inputFileDescription = new CsvFileDescription
			{
				SeparatorChar = ',',
				FirstLineHasColumnNames = true
			};
			CsvContext cc = new CsvContext();
			IEnumerable<UserClass> users = cc.Read<UserClass>("Data/Databases/UserDatabase.csv", inputFileDescription);
			List<UserClass> solution = new List<UserClass>();
			foreach(UserClass youser in users)
            {
				solution.Add(youser);
            }
			List<UserClass> lastSolution = solution.OrderBy(o => o.CurrentPoints).ToList();
			lastSolution.Reverse();
			return lastSolution;
		}
	}
}
