using BLL.Interface.Services;
using Blog.Models.ArticleViewModel;
using Blog.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Blog.Providers;
using Blog.Models;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IUserService userService;

        public ArticleController(IArticleService articleService, IUserService userService)
        {
            this.articleService = articleService;
            this.userService = userService;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [Authorize]
        public ActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateArticle(ArticleViewModel model)
        {            
            var name = HttpContext.User.Identity.Name;
            var id = userService.GetOneByPredicate(n => n.Login == name).Id;
            model.AuthorId = Convert.ToInt32(id);
            model.CountLikes = 0;
            model.PublicationDate = DateTime.Now;
            articleService.Create(model.GetBllEntity());
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult DeleteArticle(int articleId)
        {
            articleService.Delete(articleService.GetOneByPredicate(a => a.Id == articleId));
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult UpdateArticle(int articleId)
        {
            var article = articleService.GetOneByPredicate(a => a.Id == articleId).
                    GetMvcEntity();
            return View(article);
        }

        [HttpPost]
        [Authorize]
        public ActionResult UpdateArticle(ArticleViewModel model)
        {
            model.PublicationDate = DateTime.Now;
            articleService.Edit(model.GetBllEntity());
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ShowArticles(int page = 1)
        {
            var articles = articleService.GetAllEntities().
                    OrderByDescending(a => a.PublicationDate).
                        Select(a => a.GetMvcEntity());

            List<ArticleViewModel> models = new List<ArticleViewModel>();
            foreach (var article in articles)
            {
                //article.User = userService.GetById(article.User.UserId).GetMvcEntity();
                models.Add(article);
            }

            int pageSize = 3;
            IEnumerable<ArticleViewModel> articleModels = models.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = models.Count };
            @ViewBag.PageInfo = pageInfo;
            return PartialView(articleModels);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ShowArticle(int articleId) 
        {           
            var article = articleService.GetOneByPredicate(u => u.Id == articleId).GetMvcEntity();
            article.User = userService.GetById(article.AuthorId).GetMvcEntity();
            return PartialView(article);
        }

        public ActionResult ShowPages(IEnumerable<ArticleViewModel> models, int page = 1)
        {
            int pageSize = 3;
            IEnumerable<ArticleViewModel> articleModels = models.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = models.Count() };
            @ViewBag.PageInfo = pageInfo;
            return PartialView("ShowArticles", articleModels);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ViewArticle(int articleId)
        {
            var article = articleService.GetOneByPredicate(u => u.Id == articleId).GetMvcEntity();            
            article.CountLikes+=1;
            articleService.Edit(article.GetBllEntity());
            article.User = userService.GetById(article.AuthorId).GetMvcEntity();
            return View(article);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ViewBloggerArticles(int bloggerId)
        {
            var user = userService.GetById(bloggerId);
            var articles = articleService.GetAllByPredicate(u => u.AuthorId == bloggerId).
                    OrderByDescending(a => a.PublicationDate).Select(a => a.GetMvcEntity());
            List<ArticleViewModel> models = new List<ArticleViewModel>();
            foreach (var article in articles)
            {
                //article.User = userService.GetById(article.User.UserId).GetMvcEntity();
                models.Add(article);
            }
            @ViewBag.BloggerLogin = user.Login;
            return View("BloggerArticles", models);
        }

    }
}