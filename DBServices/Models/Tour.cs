using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices.Models
{
    public class Tour
    {
        public int TourID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
