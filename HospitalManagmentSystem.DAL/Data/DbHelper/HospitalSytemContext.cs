using HospitalManagmentSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.DAL.Data.DbHelper
{
    public class HospitalSytemContext : IdentityDbContext<ApplicationUser>
    {
        public HospitalSytemContext(DbContextOptions<HospitalSytemContext> options):base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Issuse> Issuses { get; set; }
    }
}
