using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices.Models
{
    public class VisitorModel
    {
        public int VisitorModelID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Gender { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
