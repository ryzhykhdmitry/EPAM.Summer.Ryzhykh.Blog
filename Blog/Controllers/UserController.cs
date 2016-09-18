using BLL.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService service;
        // GET: User
        public UserController(IUserService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            var user = service.GetOneByPredicate(u => u.Login == "Second");
            //var user = service.GetById(2).Login;
            ViewBag.Login = user.Login;
            return View();
        }
    }
}