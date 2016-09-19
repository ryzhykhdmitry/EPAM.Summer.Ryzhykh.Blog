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
        // GET: Article
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
            //MembershipUser user = ((CustomMembershipProvider)Membership.Provider).GetUser(HttpContext.User.Identity.Name, true);
            var name = HttpContext.User.Identity.Name;
            var id = userService.GetOneByPredicate(n => n.Login == name).Id;
            model.AuthorId = Convert.ToInt32(id);/*(HttpContext.Profile.GetPropertyValue("Id"));*/
            model.CountLikes = 0;
            model.PublicationDate = DateTime.Now;
            articleService.Create(model.GetBllEntity());
            return View();
        }
    }
}