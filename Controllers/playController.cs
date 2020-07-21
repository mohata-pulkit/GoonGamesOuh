using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoonGamesOuh.Models;
using GoonGamesOuh.Data.Readers;
using GoonGamesOuh.Data.Classes;
using Microsoft.AspNetCore.Http;

namespace GoonGamesOuh.Controllers
{
	public class playController : Controller
	{
		static play Solution = new play();

		static UserClass user = new UserClass();

		static int id = new int();

		static int UNumber = new int();
		public ActionResult Index()
        {
			return RedirectToAction("Question");
        }
		public ViewResult Question()
		{
			if (HttpContext.Session.GetInt32("User Number") != null)
			{
				UNumber = Convert.ToInt32(HttpContext.Session.GetInt32("User Number"));

				user = UserReader.getUser(UNumber);
				id = user.CurrentQuestion;
			}
            else
            {
				id = 0;
            }

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
				UserWriter.nextQuestion(UNumber);
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
