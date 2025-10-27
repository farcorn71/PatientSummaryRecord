using Microsoft.EntityFrameworkCore;
using PatientSummaryRecord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientSummaryRecord.Infrastructure.Data
{
    public class PatientDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, NHSNumber = "1234567890", Name = "Lloyd Smith", DateOfBirth = new DateTime(1985, 4, 12), GPPractice = "Northumbria Clinic" },
                new Patient { Id = 2, NHSNumber = "9876623210", Name = "Rodrigues Johnson", DateOfBirth = new DateTime(1976, 9, 23), GPPractice = "Southhumbria Health" },
                new Patient { Id = 3, NHSNumber = "7755885566", Name = "Powell Lee", DateOfBirth = new DateTime(1990, 1, 5), GPPractice = "Westumbria Medical" }
            );
        }
    }
}
