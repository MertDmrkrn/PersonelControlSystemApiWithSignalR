using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-Q80IDIO; initial Catalog=PersonelControlSystemDb;integrated Security=true; TrustServerCertificate=true;");
        }

        public DbSet<Personel> Personels { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Shift> Shifts { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<OhsReport> OhsReports { get; set; }

        public DbSet<Notification> Notifications { get; set; }
    }
}
