using DBServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices
{
    class DBServiceContext : DbContext
    {
        public DBServiceContext() : base("OpenWisata") {}
        public virtual DbSet<VisitorModel> Visitors { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
    }
}
