using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DBServices.Helpers;
using DBServices.Models;

namespace DBServices.Services
{
    public class VisitorService : ICRUDService
    {
        DBServiceContext _context = new DBServiceContext();

        async Task<bool> ICRUDService.Create(
            string name, 
            string email, 
            int age, 
            string gender, 
            string password)
        {
            _context.Visitors.Add(new VisitorModel { 
                Name = name,
                Email = email,
                Age = age,
                Gender = gender,
                Password = MD5Hash.GetMD5(password),
            });

            await _context.SaveChangesAsync();
            return true;
        }

        async Task<Array> ICRUDService.FindID(int id)
        {
            var visitor = await _context.Visitors.Where(v => v.VisitorModelID == id).ToArrayAsync();
            return visitor;
        }

        public List<VisitorModel> GetVisitors()
        {
            List<VisitorModel> visitors = new List<VisitorModel>();
            var list_visitor = _context.Visitors.ToList();

            foreach (var v in list_visitor)
            {
                visitors.Add(v);
            }

            return visitors;
        }

        Task<bool> ICRUDService.Update(int id)
        {
            throw new NotImplementedException();
        }

        bool ICRUDService.Delete(int id)
        {
            VisitorModel visitor = _context.Visitors.Where(v => v.VisitorModelID == id).FirstOrDefault();
            _context.Visitors.Remove(visitor);
            if (_context.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }
    }
}
