using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using WebUI.Models;
using Domain.Enities;
using System.Web.Security;


namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository repository;

        public AccountController(IAccountRepository repo)
        {
            repository = repo;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                AccountInfo account = new AccountInfo
                {
                    Accounts = repository.Accounts
                };
                Account user = account.Accounts.FirstOrDefault(a => a.AccountName == model.Name && a.AccountPassword == model.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Admin", null);
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Admin");
        }
    }
}