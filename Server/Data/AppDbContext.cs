using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerTraining.Server.Data;
using DockerTraining.Shared;
using Microsoft.EntityFrameworkCore;

namespace DockerTraining.Server .Data
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
        }
    }
}
