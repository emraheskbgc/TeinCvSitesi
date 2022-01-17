using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeinCvSitesi.Identity;
using TeinCvSitesi.Models;

namespace TeinCvSitesi.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detay()
        {
            return View();
        }
        
       


    }
}