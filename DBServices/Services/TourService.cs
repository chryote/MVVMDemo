using DBServices.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices.Services
{
    public class TourService : ICRUDService
    {
        private DBServiceContext _context = new DBServiceContext();

        Task<bool> ICRUDService.Create(string name, string email, int age, string gender, string password)
        {
            throw new NotImplementedException();
        }

        bool ICRUDService.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Task<Array> ICRUDService.FindID(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICRUDService.Update(int id)
        {
            throw new NotImplementedException();
        }
        public bool AddToMyTour(int VisitorID, int TourID)
        {
            var enrol = new Enrollment { TourID = TourID, VisitorModelID = VisitorID, Is_Active = true };
            _context.Enrollments.Add(enrol);
            return true;
        }
        public List<Tour> GetTours()
        {
            List<Tour> tours = new List<Tour>();
            var list_tour = _context.Tours.ToList();

            foreach (var v in list_tour)
            {
                tours.Add(v);
            }

            return tours;
        }

        public List<Tour> GetToursByID(int user_id)
        {
            List<Tour> tours = new List<Tour>();
            var list_tour = _context.Enrollments
                .Where(v => v.TourID == user_id)
                .ToList();

            foreach (var v in list_tour)
            {
                tours.Add(v.Tour);
            }

            return tours;
        }
    }
}
