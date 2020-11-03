using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBServices.Models;
using DBServices.Services;
using DBServices.Helpers;

namespace DBServices
{
    class Program
    {
        static void Main(string[] args)
        {
            // Adding Dummy Data
            using (var context = new DBServiceContext())
            {
                // Visitor 1
                var visitor1 = new VisitorModel
                {
                    Name = "Bima Jikope",
                    Email = "Bima@gmail.com",
                    Password = MD5Hash.GetMD5("admin123"),
                    Age = 25,
                    Gender = "Male",
                    Country = "United States",
                };

                // Visitor 2
                var visitor2 = new VisitorModel
                {
                    Name = "Bima Wiratama",
                    Email = "bimakope@gmail.com",
                    Password = MD5Hash.GetMD5("admin123"),
                    Age = 20,
                    Gender = "Male",
                    Country = "Indonesia",
                };

                // Visitor 3
                var visitor3 = new VisitorModel
                {
                    Name = "Master of Flute",
                    Email = "bimakope1@gmail.com",
                    Password = MD5Hash.GetMD5("admin123"),
                    Age = 999,
                    Gender = "Unknown",
                    Country = "United Kingdom",
                };

                context.Visitors.Add(visitor1);
                context.Visitors.Add(visitor2);
                context.Visitors.Add(visitor3);

                // Tour 1
                var tour1 = new Tour
                {
                    Name = "Kraton Jogja",
                    Price = 20000,
                    Description = "The Place of Kasultanan Yogyakarta",
                    Date = DateTime.Parse(DateTime.Now.ToString()),
                };

                // Tour 2
                var tour2 = new Tour
                {
                    Name = "Kraton Solo",
                    Price = 15000,
                    Description = "The Place of Kasunanan Surakarta",
                    Date = DateTime.Parse(DateTime.Now.ToString()),
                };

                // Tour 3
                var tour3 = new Tour
                {
                    Name = "Komodo Island",
                    Price = 1000000,
                    Description = "Island of Ancient Animals",
                    Date = DateTime.Parse(DateTime.Today.AddDays(3).ToString()),
                };

                context.Tours.Add(tour1);
                context.Tours.Add(tour2);
                context.Tours.Add(tour3);

                // Adding Relationship
                var enrollment1 = new Enrollment
                {
                    VisitorModel = visitor1,
                    Tour = tour1,
                    Is_Active = true,
                };

                var enrollment2 = new Enrollment
                {
                    VisitorModel = visitor2,
                    Tour = tour2,
                    Is_Active = true,
                };

                var enrollment3 = new Enrollment
                {
                    VisitorModel = visitor3,
                    Tour = tour1,
                    Is_Active = true,
                };
                context.Enrollments.Add(enrollment1);
                context.Enrollments.Add(enrollment2);
                context.Enrollments.Add(enrollment3);

                // Save changes to database
                context.SaveChanges();
            }

            Console.WriteLine("Getting Data");
            VisitorService visitorManager = new VisitorService();

            List<VisitorModel> visitors = new List<VisitorModel>();

            visitors = visitorManager.GetVisitors();
            Console.WriteLine(visitors.GetType());

            foreach (var v in visitors)
            {
                Console.WriteLine(v.Name);
                Console.WriteLine(v.Email);
                Console.WriteLine(v.Gender);
                Console.WriteLine(v.Age);
                Console.WriteLine(v.Country);
            }

            //string hashed = MD5Hash.GetMD5("test");

            //string hashed2 = MD5Hash.GetMD5("test1");

            //Console.WriteLine(hashed);
            //Console.WriteLine(hashed2);

            //if (hashed == hashed2)
            //{
            //    Console.WriteLine("Sama");
            //}

            Console.ReadKey();
        }
    }
}
