using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeinCvSitesi.Identity;
using TeinCvSitesi.Models;

namespace TeinCvSitesi.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register model) 
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.UserName = model.UserName;
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("Hata", "Kullanıcı Oluşturma Hatası");
                }
                
            }
            return View(model);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.UserName, model.Password);
                if (user!=null)
                {
                    var autManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var autProperties = new AuthenticationProperties();
                    autProperties.IsPersistent = model.RememberMe;
                    autManager.SignIn(autProperties, identityclaims);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Hata", "Böyle Bir Kullanıcı Yok");
                }
            }
            return View(model);
        }
        public ActionResult LogOut()
        {
            var autManager = HttpContext.GetOwinContext().Authentication;
            autManager.SignOut();
            return RedirectToAction("Index","Home");
        }
        //Get
        public ActionResult Profil()
        {
            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();
            var user = UserManager.FindById(id);
            var data = new ProfileUpdate()
            {
                Id = user.Id,
                Name = user.Name,
                SurName=user.SurName,
                Email=user.Email,
                PhoneNumber=user.PhoneNumber,
                UserName=user.UserName

            };
            return View(data);
        }
        [HttpPost]
        public ActionResult Profil( ProfileUpdate model)
        {
            var user = UserManager.FindById(model.Id);
            user.Name = model.Name;
            user.SurName = model.SurName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.UserName = model.UserName;
            
            
            
            
           
            UserManager.Update(user);

            return View("Update");

        }
        public ActionResult SifreDegistir()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult SifreDegistir(PasswordChange model)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.ChangePassword(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                return View("Update");
            }
            return View(model);
        }
    }
}