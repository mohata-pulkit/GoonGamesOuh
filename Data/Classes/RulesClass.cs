using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LINQtoCSV;

namespace GoonGamesOuh.Data.Classes
{
	public class RulesClass
	{
		[CsvColumn(Name = "Rule", FieldIndex = 1)]
		public string rule { get; set; }
	}
}
