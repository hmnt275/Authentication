using Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authentication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult abc(User model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new SqlDbContex())
                {
                    User user = context.Users
                                       .Where(u => u.UserId == model.UserId && u.Password == model.Password)
                                       .FirstOrDefault();

                    if (user != null)
                    {
                        Session["UserName"] = user.UserName;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid User Name or Password");
                        return View(model);
                    }
                }
            }
            else
            {
                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session["UserName"] = string.Empty;
            return RedirectToAction("Index", "Home");
        }
    }
}