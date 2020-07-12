using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoonGamesOuh.Data.Classes;
using GoonGamesOuh.Models;
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
        public static void nextQuestion(int userNumber)
        {
            UserClass myUser = UserReader.getUser(userNumber);

            myUser.CurrentQuestion = myUser.CurrentQuestion + 1;
            myUser.CurrentPoints = myUser.CurrentPoints + 400;

            CsvFileDescription outputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };
            List<UserClass> user = new List<UserClass>();
            for (int i = 1; i < myUser.UserNumber; i++)
            {
                user.Add(UserReader.getUser(i));
            }

            user.Add(myUser);

            for (int i = myUser.UserNumber + 1; i <= UserReader.getMaxUsers(); i++)
            {
                user.Add(UserReader.getUser(i));
            }
            CsvContext cc = new CsvContext();

            cc.Write(user, "Data/Databases/UserDatabase.csv", outputFileDescription);
        }
    }
}
