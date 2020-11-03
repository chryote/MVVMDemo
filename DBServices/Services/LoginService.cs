using DBServices.Helpers;
using DBServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices.Services
{
    public class LoginService
    {
        private DBServiceContext _context = new DBServiceContext();
        public int CheckLogin(string email, string password)
        {
            string hashedpassword = MD5Hash.GetMD5(password);

            VisitorModel visitor =  _context.Visitors
                .Where(v => v.Email == email)
                .Where(v => v.Password == hashedpassword)
                .FirstOrDefault();

            if (visitor != null)
            {
                return visitor.VisitorModelID;
            }
            return 0;
        }

        public VisitorModel GetUserByID(int user_id)
        {
            var visitor =  _context.Visitors
                .Where(v => v.VisitorModelID == user_id)
                .FirstOrDefault();

            return visitor;
        }
    }
}
