using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CivilRegistry_MVC;
using System.Windows.Forms;

namespace CivilRegistry_MVC.Controllers
{
    public class FamilyCertificatesController : Controller
    {
        private CivilRegistryModel db = new CivilRegistryModel();

        // GET: FamilyCertificates
        public ActionResult Index()
        {
            var familyCertificates = db.FamilyCertificates.Include(f => f.Person);
            return View(familyCertificates.ToList());
        }

        // GET: FamilyCertificates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyCertificate familyCertificate = db.FamilyCertificates.Find(id);

            string[] strArray = familyCertificate.FamilyMembers.Split(',');
            //FamilyCertificate.FamilyMembers = new List<Person>();
            familyCertificate.FamilyMembers = "";
            foreach (var item in strArray)
            {
                int i = 0;
                foreach (Person person in db.People)
                {
                    if (person.PersonalNumber == item)
                    {
                        familyCertificate.FamilyMembers += $"{person.FirstName}  {person.LastName}       ";
                        //FamilyCertificate.FamilyMembers.Add(person);
                        i++;
                    }

                }

                if (i == 0)
                {
                    MessageBox.Show(item + " Ky Numer Personal nuk ekziston");
                    //throw new Exception(item + " Ky Numer Personal nuk ekziston");
                }

            }

            if (familyCertificate == null)
            {
                return HttpNotFound();
            }
            return View(familyCertificate);
        }

        // GET: FamilyCertificates/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonalNumber");
            return View();
        }

        // POST: FamilyCertificates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FamilyCertificatesID,RegistrationDate,ExpirationDate,FamilyMembers,PersonID")] FamilyCertificate familyCertificate)
        {
            if (ModelState.IsValid)
            {
                db.FamilyCertificates.Add(familyCertificate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonalNumber", familyCertificate.PersonID);
            return View(familyCertificate);
        }

        // GET: FamilyCertificates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyCertificate familyCertificate = db.FamilyCertificates.Find(id);
            if (familyCertificate == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonalNumber", familyCertificate.PersonID);
            return View(familyCertificate);
        }

        // POST: FamilyCertificates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FamilyCertificatesID,RegistrationDate,ExpirationDate,FamilyMembers,PersonID")] FamilyCertificate familyCertificate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familyCertificate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(db.People, "PersonID", "PersonalNumber", familyCertificate.PersonID);
            return View(familyCertificate);
        }

        // GET: FamilyCertificates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyCertificate familyCertificate = db.FamilyCertificates.Find(id);
            if (familyCertificate == null)
            {
                return HttpNotFound();
            }
            return View(familyCertificate);
        }

        // POST: FamilyCertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FamilyCertificate familyCertificate = db.FamilyCertificates.Find(id);
            db.FamilyCertificates.Remove(familyCertificate);
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
