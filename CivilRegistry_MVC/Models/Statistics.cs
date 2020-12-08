using System;
using CivilRegistry_MVC.Models;
using CivilRegistry_MVC.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace CivilRegistry_MVC.Models
{
    public class Statistics
    {
        private static CivilRegistryModel db = new CivilRegistryModel();

        public static int BirthNumber()
        {
            return db.People.Count();
        }

        public static int DeathNumber()
        {
            return db.DeathCertificates.Count();
        }

        public static int MarriageNumber()
        {
            return db.MarriageCertificates.Count();
        }

        public static int MigrationNumber()
        {
            return db.Passports.Count();
        }
        public static int CalculateAge(DateTime Birthday)
        {
            int age = DateTime.Now.Year - Birthday.Year;
            if (DateTime.Now.DayOfYear < Birthday.DayOfYear)
            { age -= 1; }
            return age;
        }

    }
}