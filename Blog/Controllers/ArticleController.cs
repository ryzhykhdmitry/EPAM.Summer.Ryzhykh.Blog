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
        public ActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateArticle(ArticleViewModel model)
        {            
            var name = HttpContext.User.Identity.Name;
            var id = userService.GetOneByPredicate(n => n.Login == name).Id;
            model.AuthorId = Convert.ToInt32(id);
            model.CountLikes = 0;
            model.PublicationDate = DateTime.Now;
            articleService.Create(model.GetBllEntity());
            return View();
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
            
            return PartialView(article);
        }

    }
}