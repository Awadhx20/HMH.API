using HMH.core.Entites;
using HMH.core.Entites.Dectors;
using HMH.Core.Entites;
using HMH.Infrastructure.Data.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointments> appointments { get; set; }   

        public DbSet<Ratings> ratings { get; set; }
        public DbSet<DoctorSchedule> doctorSchedules { get; set; }
        public DbSet<Clinics> clinics { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Offer> offers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            IdentityTablesConfigrations.ConfigureIdentityTableNames(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
