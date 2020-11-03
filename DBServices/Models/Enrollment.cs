using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int VisitorModelID { get; set; }
        public int TourID { get; set; }
        public bool Is_Active { get; set; }

        public virtual Tour Tour { get; set; }
        public virtual VisitorModel VisitorModel { get; set; }
    }
}
