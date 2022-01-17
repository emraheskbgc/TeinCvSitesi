using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeinCvSitesi.Models;

namespace TeinCvSitesi.Controllers
{
    public class PersonalInfoController : Controller
    {
        private DataContext db = new DataContext();

        // GET: PersonalInfo
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var kisi = db.PersonalInfos.Where(i => i.UserName == username).Select(i => new PersonalInfoModel()
            {
                Id = i.Id,
                UserName = i.UserName,
                NameSurname=i.NameSurname,
                PhoneNumber=i.PhoneNumber,
                Email=i.Email
            }).ToList();
            return View(kisi);
        }

        // GET: PersonalInfo/Details/5
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

        // GET: PersonalInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,NameSurname,PhoneNumber,Email")] PersonalInfo personalInfo)
        {
            if (ModelState.IsValid)
            {
                db.PersonalInfos.Add(personalInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personalInfo);
        }

        // GET: PersonalInfo/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: PersonalInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,NameSurname,PhoneNumber,Email")] PersonalInfo personalInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personalInfo);
        }

        // GET: PersonalInfo/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: PersonalInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalInfo personalInfo = db.PersonalInfos.Find(id);
            db.PersonalInfos.Remove(personalInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
