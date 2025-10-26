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
                new Patient { Id = 1, NHSNumber = "1234567890", Name = "Alice Smith", DateOfBirth = new DateTime(1985, 4, 12), GPPractice = "Greenwood Clinic" },
                new Patient { Id = 2, NHSNumber = "9876543210", Name = "Bob Johnson", DateOfBirth = new DateTime(1978, 9, 23), GPPractice = "Riverside Health" },
                new Patient { Id = 3, NHSNumber = "5555555555", Name = "Charlie Lee", DateOfBirth = new DateTime(1990, 1, 5), GPPractice = "Hilltop Medical" }
            );
        }
    }
}
