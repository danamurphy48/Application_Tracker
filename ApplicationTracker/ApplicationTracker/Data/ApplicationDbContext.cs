using System;
using System.Collections.Generic;
using System.Text;
using ApplicationTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApplicationTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CompanyNote> CompanyNotes { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Interviewer> Interviewers { get; set; }
        public DbSet<HiringManager> HiringManagers { get; set; }
        public DbSet<JobInformation> JobInformations { get; set; }
        public DbSet<Network> Networks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {
                        Name = "Applicant",
                        NormalizedName = "APPLICANT"
                    }
                );
        }
    }
}
