﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Контекст на базата данни
    /// </summary>
    public class TravelContext : DbContext
    {
        /// <summary>
        /// Низ за връзка към базата данни
        /// </summary>
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WeTravel;Integrated Security=True";

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
