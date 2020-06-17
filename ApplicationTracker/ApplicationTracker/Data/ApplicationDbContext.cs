﻿using System;
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