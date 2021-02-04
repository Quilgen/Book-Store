using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookStore.Models;
using BookStore.Models.DataLayer.Repositories;
using BookStore.Models.DomainModels;
using BookStore.Models.DataLayer;
using System.Threading;

namespace BookStore.Controllers
{
	public class HomeController : Controller
	{
		private Repository<Book> data { get; set; }

		public HomeController(BookstoreContext ctx) => data = new Repository<Book>(ctx);

		public IActionResult Index()
		{
			// get random book
			var random = data.Get(new QueryOptions<Book>
			{
				OrderBy = b => Guid.NewGuid()
			});

			return View(random);
		}

		public ContentResult Register()
		{
			return Content("Registration will be created later");
		}
	}
}
