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

        [HttpGet]
        public ActionResult GetComments(int articleId)
        {
            var comments = commentService.GetAllByPredicate(u => u.ArticleId == articleId).Select(c => c.GetMvcEntity());
            return PartialView("_CommentsOfArticle", GetCommentModel(comments));
        }

        [HttpPost]
        public ActionResult DeleteComment(int articleId, int commentId)
        {
            commentService.Delete(commentService.GetAllByPredicate(u => u.Id == commentId).FirstOrDefault());
            var comments = commentService.GetAllByPredicate(u => u.ArticleId == articleId).Select(c => c.GetMvcEntity());
            return PartialView("_CommentsOfArticle", GetCommentModel(comments));
        }

        private IEnumerable<CommentViewModel> GetCommentModel(IEnumerable<CommentViewModel> comments)
        {
            if (comments == null) return null;
            List<CommentViewModel> models = new List<CommentViewModel>();
            foreach (var comment in comments)
            {
                comment.Author = userService.GetOneByPredicate(u => u.Id == comment.AuthorId).GetMvcEntity();
                models.Add(comment);
            }
            return models;
        }
    }
}