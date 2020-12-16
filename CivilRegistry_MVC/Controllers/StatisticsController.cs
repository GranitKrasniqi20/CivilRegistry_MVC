using CivilRegistry_MVC.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CivilRegistry_MVC.Controllers
{
    public class StatisticsController : Controller
    {
        private CivilRegistryModel db = new CivilRegistryModel();

        // GET: Statistics
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult OpcionalStatistics(string from, string to, string gender, string employmentStatus, string qualification, string healthCondition)
        {
            List<Person> GetSpecificPeople = new List<Person>();

            if (from != null && to != null)
            {
                int fromInt = int.Parse(from);
                int toInt = int.Parse(to);
                foreach (var item in db.People)
                {
                    if (Statistics.CalculateAge(item.Birthday) >= fromInt && Statistics.CalculateAge(item.Birthday) <= toInt)
                    {
                        if ((gender == "" || gender == item.Gender) && (employmentStatus == "" || employmentStatus == item.EmploymentStatus) && (qualification == "" ||
                            qualification == item.Qualification) && (healthCondition == "" || healthCondition == item.HealthCondition))
                        {
                            GetSpecificPeople.Add(item);
                        }
                    }
                }
                return View(GetSpecificPeople.ToList());
            }
            return View(db.People.ToList());
        }

        public ActionResult NumericalStatistics()
        {
            return View();
        }

        public ActionResult Searching(string option, string search)
        {
            if (option == "PersonalNumber")
            {
                return View(db.People.Where(x => x.PersonalNumber.StartsWith(search) || search == null).ToList());
            }
            else if (option == "FirstName")
            {
                return View(db.People.Where(x => x.FirstName.Contains(search) || search == null).ToList());
            }
            else if (option == "LastName")
            {
                return View(db.People.Where(x => x.LastName.StartsWith(search) || search == null).ToList());
            }
            else if (option == "Email")
            {
                return View(db.People.Where(x => x.Email.StartsWith(search) || search == null).ToList());
            }
            else if (option == "Address")
            {
                return View(db.People.Where(x => x.Address.StartsWith(search) || search == null).ToList());
            }
            else if (option == "BirthPlace")
            {
                return View(db.People.Where(x => x.BirthPlace.StartsWith(search) || search == null).ToList());
            }
            else if (option == "Municipality")
            {
                return View(db.People.Where(x => x.Municipality.StartsWith(search) || search == null).ToList());
            }
            else if (option == "Nationality")
            {
                return View(db.People.Where(x => x.Nationality.StartsWith(search) || search == null).ToList());
            }

            else return View(db.People.ToList());

        }
    }
}