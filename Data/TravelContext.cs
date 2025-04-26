using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TravelContext : DbContext
    {
        private string connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=WeTravel;Integrated Security=True;";

        public DbSet<Model.Customer> Customers { get; set; }

        public DbSet<Model.Travel> Travels { get; set; }

        public TravelContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connectionString);
        }

    }
}
