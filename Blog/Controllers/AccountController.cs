using BLL.Interface.Entities;
using Blog.Models.AccountViewModel;
using Blog.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {          
                return View();               
        }


        [HttpPost]       
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var user = 
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);

                    return RedirectToAction("Index", "Home");
                    //return RedirectToAction("Register", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong password or login");
                }
            }
            return RedirectToAction("Index", "Home", model);            
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var blluser = new UserEntity()
                {
                    Login = model.UserName,
                    Email = model.UserEmail,
                    Password = model.UserPassword,
                    
                };
                MembershipUser membershipUser = ((CustomMembershipProvider)Membership.Provider).CreateUser(blluser);
                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration");
                }
            }
            return View(model);
        }
    }
}