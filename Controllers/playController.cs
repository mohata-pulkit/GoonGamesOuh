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
		public static play Solution = new play();

		public UserClass user = UserReader.getUser(1);

		public int id = UserReader.getUser(1).CurrentQuestion;

		public ViewResult Question()
		{
			string PromptUnarrayed = QuestionReader.getQuestion(id).prompt;
			string[] promptArray = PromptUnarrayed.Split('\n');

			Solution.Prompt = promptArray;
			Solution.Id = id;

			Solution.HelpfulComments = QuestionReader.getQuestion(id).comments;

			return View(Solution);
		}
		[HttpPost]
		public RedirectToActionResult QuestionChecked(play input)
		{
			string answer = QuestionReader.getQuestion(id).answer;

			if (input.Answer == answer)
			{
				UserWriter.nextQuestion(1);
				Solution.ConfirmationMessage = "Correct Answer :)";
			}
			else if(input.Answer == null)
			{
				Solution.ConfirmationMessage = "Please enter a valid answer";
			}
			else
			{
				Solution.ConfirmationMessage = "Incorrect Answer :(";
			}
			return RedirectToAction("Question");
		}
	}
}
