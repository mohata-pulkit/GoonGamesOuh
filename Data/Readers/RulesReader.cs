using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoonGamesOuh.Data.Classes;
using GoonGamesOuh.Models;
using LINQtoCSV;

namespace GoonGamesOuh.Data.Readers
{
	public class RulesReader
	{
		public static string getRule(int i)
		{
			CsvFileDescription inputFileDescription = new CsvFileDescription
			{
				SeparatorChar = ',',
				FirstLineHasColumnNames = true
			};
			CsvContext cc = new CsvContext();
			IEnumerable<RulesClass> rules = cc.Read<RulesClass>("Data/Databases/RulesDatabase.csv", inputFileDescription);
			List<RulesClass> solution = new List<RulesClass>();
			foreach (RulesClass rule in rules)
			{
				solution.Add(rule);
			}
			string finalSolution = solution[i].rule;
			return finalSolution;
		}
		public static int getRuleMax()
		{
			CsvFileDescription inputFileDescription = new CsvFileDescription
			{
				SeparatorChar = ',',
				FirstLineHasColumnNames = true
			};
			CsvContext cc = new CsvContext();
			IEnumerable<RulesClass> rules = cc.Read<RulesClass>("Data/Databases/RulesDatabase.csv", inputFileDescription);

			int solution = rules.Count();

			return solution;
		}
	}
}
