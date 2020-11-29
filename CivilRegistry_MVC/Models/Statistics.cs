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
        public static int BirthNumber()
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                using (SqlCommand command = DbHelper.Command(conn, "usp_BirthNumber", CommandType.StoredProcedure))
                //using (SqlCommand command = DbHelper.Command(conn, "select count(PersonID) as number from People", CommandType.Text))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return int.Parse(reader["number"].ToString());
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
            }
        }

        public static int DeathNumber()
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                using (SqlCommand command = DbHelper.Command(conn, "usp_DeathNumber", CommandType.StoredProcedure))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return int.Parse(reader["number"].ToString());
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
            }
        }

        public static int MarriageNumber()
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                using (SqlCommand command = DbHelper.Command(conn, "usp_MarriageNumber", CommandType.StoredProcedure))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return int.Parse(reader["number"].ToString());
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
            }
        }

        public static int MigrationNumber()
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                using (SqlCommand command = DbHelper.Command(conn, "usp_MigrationNumber", CommandType.StoredProcedure))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return int.Parse(reader["number"].ToString());
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
            }
        }
        public static int CalculateAge(DateTime Birthday)
        {
            int age = DateTime.Now.Year - Birthday.Year;
            if (DateTime.Now.DayOfYear < Birthday.DayOfYear)
            { age = age - 1; }
            return age;
        }

    }
}