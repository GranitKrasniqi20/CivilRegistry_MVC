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
    public class DeathCertificatesController : Controller
    {
        private CivilRegistryModel db = new CivilRegistryModel();

        // GET: DeathCertificates
        public ActionResult Index()
        {
            var deathCertificates = db.DeathCertificates.Include(d => d.Person);
            return View(deathCertificates.ToList());
        }

        // GET: DeathCertificates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeathCertificate deathCertificate = db.DeathCertificates.Find(id);
            if (deathCertificate == null)
            {
                return HttpNotFound();
            }
            return View(deathCertificate);
        }

        // GET: DeathCertificates/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonalNumber");
            return View();
        }

        // POST: DeathCertificates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeathCertificatesID,RegistrationDate,ExpirationDate,DeathDate,PersonID")] DeathCertificate deathCertificate)
        {
            if (ModelState.IsValid)
            {
                db.DeathCertificates.Add(deathCertificate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonalNumber", deathCertificate.PersonID);
            return View(deathCertificate);
        }

        // GET: DeathCertificates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeathCertificate deathCertificate = db.DeathCertificates.Find(id);
            if (deathCertificate == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonalNumber", deathCertificate.PersonID);
            return View(deathCertificate);
        }

        // POST: DeathCertificates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeathCertificatesID,RegistrationDate,ExpirationDate,DeathDate,PersonID")] DeathCertificate deathCertificate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deathCertificate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonalNumber", deathCertificate.PersonID);
            return View(deathCertificate);
        }

        // GET: DeathCertificates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeathCertificate deathCertificate = db.DeathCertificates.Find(id);
            if (deathCertificate == null)
            {
                return HttpNotFound();
            }
            return View(deathCertificate);
        }

        // POST: DeathCertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeathCertificate deathCertificate = db.DeathCertificates.Find(id);
            db.DeathCertificates.Remove(deathCertificate);
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
