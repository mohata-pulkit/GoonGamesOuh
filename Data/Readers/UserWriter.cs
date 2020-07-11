using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoonGamesOuh.Data.Classes;
using LINQtoCSV;

namespace GoonGamesOuh.Data.Readers
{
    public class UserWriter
    {
        public static void addUser(UserClass userInput)
        {
            userInput.UserNumber = UserReader.getMaxUsers() + 1;
            CsvFileDescription outputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };
            List<UserClass> user = new List<UserClass>();

            for(int i = 1; i <= UserReader.getMaxUsers(); i++)
            {
                user.Add(UserReader.getUser(i));
            }

            user.Add(userInput);

            CsvContext cc = new CsvContext();

            cc.Write(user, "Data/Databases/UserDatabase.csv",outputFileDescription);
        }
    }
}
