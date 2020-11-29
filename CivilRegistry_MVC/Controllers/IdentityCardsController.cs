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
    public class IdentityCardsController : Controller
    {
        private CivilRegistryModel db = new CivilRegistryModel();

        // GET: IdentityCards
        public ActionResult Index()
        {
            var identityCards = db.IdentityCards.Include(i => i.Person);
            return View(identityCards.ToList());
        }

        // GET: IdentityCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityCard identityCard = db.IdentityCards.Find(id);
            if (identityCard == null)
            {
                return HttpNotFound();
            }
            return View(identityCard);
        }

        // GET: IdentityCards/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonalNumber");
            return View();
        }

        // POST: IdentityCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdentityCardID,RegistrationDate,ExpirationDate,PersonID")] IdentityCard identityCard)
        {
            if (ModelState.IsValid)
            {
                db.IdentityCards.Add(identityCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonalNumber", identityCard.PersonID);
            return View(identityCard);
        }

        // GET: IdentityCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityCard identityCard = db.IdentityCards.Find(id);
            if (identityCard == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonalNumber", identityCard.PersonID);
            return View(identityCard);
        }

        // POST: IdentityCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdentityCardID,RegistrationDate,ExpirationDate,PersonID")] IdentityCard identityCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(identityCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonalNumber", identityCard.PersonID);
            return View(identityCard);
        }

        // GET: IdentityCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityCard identityCard = db.IdentityCards.Find(id);
            if (identityCard == null)
            {
                return HttpNotFound();
            }
            return View(identityCard);
        }

        // POST: IdentityCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IdentityCard identityCard = db.IdentityCards.Find(id);
            db.IdentityCards.Remove(identityCard);
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
