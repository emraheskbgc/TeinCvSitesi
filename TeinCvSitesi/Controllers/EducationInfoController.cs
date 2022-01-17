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
    public class EducationInfoController : Controller
    {
        private DataContext db = new DataContext();

        // GET: EducationInfo
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var egitim = db.EducationInfos.Where(i => i.UserName == username).Select(i => new EducationInfoModel()
            {
                Id = i.Id,
                UserName = i.UserName,
             SchoolName=i.SchoolName,
             Departman=i.Departman,
             Year=i.Year
            }).ToList();
            return View(egitim);
        }

        // GET: EducationInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationInfo educationInfo = db.EducationInfos.Find(id);
            if (educationInfo == null)
            {
                return HttpNotFound();
            }
            return View(educationInfo);
        }

        // GET: EducationInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EducationInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,SchoolName,Departman,Year")] EducationInfo educationInfo)
        {
            if (ModelState.IsValid)
            {
                db.EducationInfos.Add(educationInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(educationInfo);
        }

        // GET: EducationInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationInfo educationInfo = db.EducationInfos.Find(id);
            if (educationInfo == null)
            {
                return HttpNotFound();
            }
            return View(educationInfo);
        }

        // POST: EducationInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,SchoolName,Departman,Year")] EducationInfo educationInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(educationInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(educationInfo);
        }

        // GET: EducationInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EducationInfo educationInfo = db.EducationInfos.Find(id);
            if (educationInfo == null)
            {
                return HttpNotFound();
            }
            return View(educationInfo);
        }

        // POST: EducationInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EducationInfo educationInfo = db.EducationInfos.Find(id);
            db.EducationInfos.Remove(educationInfo);
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
