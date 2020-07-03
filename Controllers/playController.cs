using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoonGamesOuh.Models;
using GoonGamesOuh.Databases;
using GoonGamesOuh.Databases.Readers;

namespace GoonGamesOuh.Controllers
{
	public class playController : Controller
	{
		public ViewResult Question()
		{
			int id = 1;
			play Question = new play() { Prompt = QuestionReader.getQuestion(id).prompt, Id = id };
			return View(Question);
		}
	}
}
