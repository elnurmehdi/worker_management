using Microsoft.EntityFrameworkCore;
using WorkerManagement.Employee.Models;

namespace WorkerManagement.Database.DataBaseAccess
{
    public class DataContext : DbContext
    {



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-DOJ9MHV;Database=Worker;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Worker> Workers { get; set; }


    }
}
