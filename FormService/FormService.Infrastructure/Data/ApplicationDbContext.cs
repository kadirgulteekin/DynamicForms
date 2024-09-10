using FormService.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormService.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Form> Forms { get; set; }
        public DbSet<FormField> FormFields { get; set; }
        public DbSet<FormData> FormData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Form>()
            .HasKey(f => f.UUID);

            modelBuilder.Entity<FormField>()
            .HasKey(ff => ff.Id);

            modelBuilder.Entity<FormField>()
                .Property(ff => ff.Id)
                .ValueGeneratedOnAdd(); 
        }
    }


}
