using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class HolidaysContext : DbContext
    {
        public HolidaysContext(DbContextOptions<HolidaysContext> options)
           : base(options)
        {

        }
        public DbSet<Client> Client { get; set; }

        public DbSet<Booking> Booking { get; set; }

        public DbSet<Service> Service { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
