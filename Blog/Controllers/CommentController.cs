using BLL.Interface.Services;
using Blog.Models.CommentViewModel;
using Blog.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IUserService userService;

        public CommentController(ICommentService commentService, IUserService userService)
        {
            this.commentService = commentService;
            this.userService = userService;
        }
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult AddComment()
        {
            return PartialView("_CreateComment");
        }

        [HttpPost]
        public ActionResult AddComment(CommentViewModel model, int articleId)
        {
            model.PublicationDate = DateTime.Now;
            model.AuthorId = Convert.ToInt32(HttpContext.Profile.GetPropertyValue("Id"));
            model.ArticleId = articleId;
            commentService.Create(model.GetBllEntity());
            return GetComments(model.ArticleId);
        }

        private ActionResult GetComments(int articleId)
        {
            throw new NotImplementedException();
        }
    }
}