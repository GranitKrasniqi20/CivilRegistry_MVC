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
    public class BirthCertificatesController : Controller
    {
        private CivilRegistryModel db = new CivilRegistryModel();

        // GET: BirthCertificates
        public ActionResult Index()
        {
            var birthCertificates = db.BirthCertificates.Include(b => b.Father).Include(b => b.Mother).Include(b => b.Person);
            return View(birthCertificates.ToList());
        }

        // GET: BirthCertificates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BirthCertificate birthCertificate = db.BirthCertificates.Find(id);
            if (birthCertificate == null)
            {
                return HttpNotFound();
            }
            return View(birthCertificate);
        }

        // GET: BirthCertificates/Create
        public ActionResult Create()
        {
            ViewBag.FatherID = new SelectList(db.People, "PersonID", "PersonalNumber");
            ViewBag.MotherID = new SelectList(db.People, "PersonID", "PersonalNumber");
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonalNumber");
            return View();
        }

        // POST: BirthCertificates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BirthCertificateID,RegistrationDate,ExpirationDate,CivilStatus,PersonID,FatherID,MotherID")] BirthCertificate birthCertificate)
        {
            if (ModelState.IsValid)
            {
                db.BirthCertificates.Add(birthCertificate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FatherID = new SelectList(db.People, "PersonID", "PersonalNumber", birthCertificate.FatherID);
            ViewBag.MotherID = new SelectList(db.People, "PersonID", "PersonalNumber", birthCertificate.MotherID);
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonalNumber", birthCertificate.PersonID);
            return View(birthCertificate);
        }

        // GET: BirthCertificates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BirthCertificate birthCertificate = db.BirthCertificates.Find(id);
            if (birthCertificate == null)
            {
                return HttpNotFound();
            }
            ViewBag.FatherID = new SelectList(db.People, "PersonID", "PersonalNumber", birthCertificate.FatherID);
            ViewBag.MotherID = new SelectList(db.People, "PersonID", "PersonalNumber", birthCertificate.MotherID);
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonalNumber", birthCertificate.PersonID);
            return View(birthCertificate);
        }

        // POST: BirthCertificates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BirthCertificateID,RegistrationDate,ExpirationDate,CivilStatus,PersonID,FatherID,MotherID")] BirthCertificate birthCertificate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(birthCertificate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FatherID = new SelectList(db.People, "PersonID", "PersonalNumber", birthCertificate.FatherID);
            ViewBag.MotherID = new SelectList(db.People, "PersonID", "PersonalNumber", birthCertificate.MotherID);
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonalNumber", birthCertificate.PersonID);
            return View(birthCertificate);
        }

        // GET: BirthCertificates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BirthCertificate birthCertificate = db.BirthCertificates.Find(id);
            if (birthCertificate == null)
            {
                return HttpNotFound();
            }
            return View(birthCertificate);
        }

        // POST: BirthCertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BirthCertificate birthCertificate = db.BirthCertificates.Find(id);
            db.BirthCertificates.Remove(birthCertificate);
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
