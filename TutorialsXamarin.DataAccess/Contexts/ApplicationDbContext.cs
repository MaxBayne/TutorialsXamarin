
using Microsoft.EntityFrameworkCore;
using TutorialsXamarin.DataAccess.Models;

namespace TutorialsXamarin.DataAccess.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer();
        }


        public DbSet<Customer> Customers{ get; set; }


    }
}