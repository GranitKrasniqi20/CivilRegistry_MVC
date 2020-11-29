using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CivilRegistry_MVC;

namespace CivilRegistry_MVC.Controllers
{
    public class MarriageCertificatesController : Controller
    {
        private CivilRegistryModel db = new CivilRegistryModel();

        // GET: MarriageCertificates
        public ActionResult Index()
        {
            var marriageCertificates = db.MarriageCertificates.Include(m => m.Partner1).Include(m => m.Partner2);
            return View(marriageCertificates.ToList());
        }

        // GET: MarriageCertificates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarriageCertificate marriageCertificate = db.MarriageCertificates.Find(id);
            if (marriageCertificate == null)
            {
                return HttpNotFound();
            }
            return View(marriageCertificate);
        }

        // GET: MarriageCertificates/Create
        public ActionResult Create()
        {
            ViewBag.Partner1ID = new SelectList(db.People, "PersonID", "PersonalNumber");
            ViewBag.Partner2ID = new SelectList(db.People, "PersonID", "PersonalNumber");
            return View();
        }

        // POST: MarriageCertificates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarriageCertificateID,RegistrationDate,ExpirationDate,MarriageDate,Partner1ID,Partner2ID")] MarriageCertificate marriageCertificate)
        {
            if (ModelState.IsValid)
            {
                db.MarriageCertificates.Add(marriageCertificate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Partner1ID = new SelectList(db.People, "PersonID", "PersonalNumber", marriageCertificate.Partner1ID);
            ViewBag.Partner2ID = new SelectList(db.People, "PersonID", "PersonalNumber", marriageCertificate.Partner2ID);
            return View(marriageCertificate);
        }

        // GET: MarriageCertificates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarriageCertificate marriageCertificate = db.MarriageCertificates.Find(id);
            if (marriageCertificate == null)
            {
                return HttpNotFound();
            }
            ViewBag.Partner1ID = new SelectList(db.People, "PersonID", "PersonalNumber", marriageCertificate.Partner1ID);
            ViewBag.Partner2ID = new SelectList(db.People, "PersonID", "PersonalNumber", marriageCertificate.Partner2ID);
            return View(marriageCertificate);
        }

        // POST: MarriageCertificates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MarriageCertificateID,RegistrationDate,ExpirationDate,MarriageDate,Partner1ID,Partner2ID")] MarriageCertificate marriageCertificate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marriageCertificate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Partner1ID = new SelectList(db.People, "PersonID", "PersonalNumber", marriageCertificate.Partner1ID);
            ViewBag.Partner2ID = new SelectList(db.People, "PersonID", "PersonalNumber", marriageCertificate.Partner2ID);
            return View(marriageCertificate);
        }

        // GET: MarriageCertificates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarriageCertificate marriageCertificate = db.MarriageCertificates.Find(id);
            if (marriageCertificate == null)
            {
                return HttpNotFound();
            }
            return View(marriageCertificate);
        }

        // POST: MarriageCertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MarriageCertificate marriageCertificate = db.MarriageCertificates.Find(id);
            db.MarriageCertificates.Remove(marriageCertificate);
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
