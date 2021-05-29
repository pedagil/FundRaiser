using FundRaiser.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundRaiser.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Creator> Creator { get; set; }
        public DbSet<Backer> Backer { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<FundProject> FundProject { get; set; }
        public DbSet<Reward> Reward { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=FundRaiserDB; User Id=sa; Password=admin!@#123");
        }
    }
}
