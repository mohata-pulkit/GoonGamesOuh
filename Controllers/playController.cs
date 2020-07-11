using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoonGamesOuh.Models;
using GoonGamesOuh.Data.Readers;
using GoonGamesOuh.Data.Classes;

namespace GoonGamesOuh.Controllers
{
	public class playController : Controller
	{
		public UserClass user = UserReader.getUser(1);
		public int id = UserReader.getUser(1).CurrentQuestion;
		public ViewResult Question()
		{
			string PromptUnarrayed = QuestionReader.getQuestion(id).prompt;
			string[] promptArray = PromptUnarrayed.Split('\n');

			play Solution = new play();

			Solution.Prompt = promptArray;
			Solution.Id = id;

			return View(Solution);
		}
		[HttpPost]
		public ActionResult QuestionChecked(play input)
		{
			play Solution = new play();

			string answer = QuestionReader.getQuestion(id).answer;

			Solution.Id = id;

			string PromptUnarrayed = QuestionReader.getQuestion(id).prompt;
			string[] promptArray = PromptUnarrayed.Split('\n');

			Solution.Prompt = promptArray;

			if (input.Answer == answer)
			{
				Solution.ConfirmationMessage = "Correct Answer :)";
				return View("Question",Solution);
			}
			else if(input.Answer == null)
			{
				return View("Question", Solution);
			}
			else
			{
				Solution.ConfirmationMessage = "Incorrect Answer :(";
				return View("Question", Solution);
			}
		}
	}
}
