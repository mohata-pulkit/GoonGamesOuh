using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LINQtoCSV;

namespace GoonGamesOuh.Databases.Readers
{
	public class QuestionReader
	{
		public static QuestionClass getQuestion(int id)
		{
			CsvFileDescription inputFileDescription = new CsvFileDescription
			{
				SeparatorChar = ',',
				FirstLineHasColumnNames = true
			};
			CsvContext cc = new CsvContext();
			IEnumerable<QuestionClass> questions = cc.Read<QuestionClass>("Data/Databases/QuestionsDatabase.csv", inputFileDescription);
			foreach(QuestionClass quest in questions)
			{
				if (quest.questionNumber == id)
				{
					return quest;
				}
			}
			return null;
		}
	}
}
