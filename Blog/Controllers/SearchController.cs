using BLL.Interface.Services;
using Blog.Infrastructure.Mappers;
using Blog.Models;
using Blog.Models.ArticleViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class SearchController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IUserService userService;

        public SearchController(IArticleService articleService, IUserService userService)
        {
            this.articleService = articleService;
            this.userService = userService;
        }

        [ChildActionOnly]
        public ActionResult Index()
        {
            return PartialView("~/Views/Shared/_Search.cshtml");
        }

        public ActionResult Search(SearchViewModel model)
        {
            List<ArticleViewModel> list = new List<ArticleViewModel>();
            var result = articleService.GetAllByPredicate(u => u.Title.Contains(model.SearchString)).
                    Select(r => r.GetMvcEntity());
            foreach (var article in result)
            {
                article.User = userService.GetById(article.AuthorId).GetMvcEntity();
                list.Add(article);
            }

            ViewBag.QuerySearch = model.SearchString;

            return View("", list);
        }

        [HttpPost]
        public ActionResult SearchJson(SearchViewModel model)
        {
            var result = articleService.GetAllByPredicate(u => u.Title.Contains(model.SearchString)).
                    Select(r => r.GetMvcEntity());
            if (result.ToArray().Length == 0)
            {
                return new JsonResult()
                {
                    Data = new { message = "No results found" }
                };
               
            }
            return Json(result);
        }

        [HttpGet]
        public ActionResult Search()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}