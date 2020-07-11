using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LINQtoCSV;

namespace GoonGamesOuh.Data
{
	public class QuestionClass
	{
		[CsvColumn(Name = "Question Number", FieldIndex = 1)]
		public int questionNumber { get; set; }
		[CsvColumn(Name = "Prompt", FieldIndex = 2, CanBeNull = false)]
		public string prompt { get; set; }
		[CsvColumn(Name = "Answer", FieldIndex = 3)]
		public string answer { get; set; }
	}
}
