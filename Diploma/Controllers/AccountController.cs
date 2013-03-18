using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Diploma.Models;

namespace Diploma.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogOn(Models.Account user)
        {
            if (ModelState.IsValid)
            {
                if (user.IsValid(user.email, user.password))
                {
                    FormsAuthentication.SetAuthCookie(user.email, user.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль!");
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterAccount model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Attempt to register the user
                    var entity = new DiplomEntities();
                    entity.AddToAuthorization(new Authorization
                        {
                            email = model.email,
                            pass = FormsAuthentication.HashPasswordForStoringInConfigFile(model.password, "SHA1"),
                            first_name = model.first_name,
                            last_name = model.last_name,
                            phone = model.phone
                        });
                    entity.SaveChanges();
                    FormsAuthentication.SetAuthCookie(model.email, false);
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            catch(Exception ex)
            {
                return RedirectToAction("showError", ex.Message);
            }
        }
    }
}
