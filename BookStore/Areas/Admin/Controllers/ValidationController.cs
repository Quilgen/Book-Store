using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Areas.Admin.Models;
using BookStore.Models.DataLayer;
using BookStore.Models.DataLayer.Repositories;
using BookStore.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ValidationController : Controller
    {
        private Repository<Author> authorData { get; set; }
        private Repository<Genre> genreData { get; set; }

        public ValidationController(BookstoreContext ctx)
        {
            authorData = new Repository<Author>(ctx);
            genreData = new Repository<Genre>(ctx);
        }

        public JsonResult CheckGenre(string genreId)
        {
            var validate = new Validate(TempData);
            validate.CheckGenre(genreId, genreData);
            
            if (validate.IsValid)
            {
                validate.MarkGenreChecked();
                return Json(true);
            }
            else
            {
                return Json(validate.ErrorMessage);
            }
        }

        public JsonResult CheckAuthor(string firstName, string lastName, string operation) 
        {
            var validate = new Validate(TempData);
            validate.CheckAuthor(firstName, lastName, operation, authorData);

            if (validate.IsValid)
            {
                validate.MarkAuthorChecked();
                return Json(true);
            }
            else
            {
                return Json(validate.ErrorMessage);
            }
        }


    }
}