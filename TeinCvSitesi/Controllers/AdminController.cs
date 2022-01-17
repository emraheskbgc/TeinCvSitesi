using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeinCvSitesi.Identity;
using TeinCvSitesi.Models;

namespace TeinCvSitesi.Controllers
{
    public class AdminController : Controller
        
    {
        private DataContext db = new DataContext();
       
        // GET: Admin

        public ActionResult Index()
        {
            return View(db.PersonalInfos.ToList());
        }
        public ActionResult Details(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalInfo personalInfo = db.PersonalInfos.Find(id);
            if (personalInfo == null)
            {
                return HttpNotFound();
            }
            return View(personalInfo);

        }
        public ActionResult SkillDetails(int id)
        {

            var beceriler = db.Skills.Where(i => i.PersonalInfo.Id == id && i.PersonalInfo.Id==i.PersonalInfo.Id).Select(i => new SkillModel()
            {
                Id = i.Id,
                UserName = i.UserName,
                SkillName = i.SkillName,
                Degree = i.Degree,
                PersonalInfo_Id=i.PersonalInfo.Id

            }).ToList();
            return View(beceriler);

        }
        public ActionResult ExperienceDetails(int id)
        {

            var deneyimler = db.Experiences.Where(i => i.PersonalInfo.Id == id ).Select(i => new ExperienceModel()
            {
                Id = i.Id,
                UserName = i.UserName,
                WorkplaceName=i.WorkplaceName,
                WorkYear=i.WorkYear,
                Description=i.Description
                
               

            }).ToList();
            return View(deneyimler);

        }
        public ActionResult EducationInfoDetails(int id)
        {

            var egitimler = db.EducationInfos.Where(i => i.PersonalInfo.Id == id).Select(i => new EducationInfoModel()
            {
                Id = i.Id,
                UserName = i.UserName,
              SchoolName=i.SchoolName,
              Departman=i.Departman,
              Year=i.Year



            }).ToList();
            return View(egitimler);

        }


    }
}