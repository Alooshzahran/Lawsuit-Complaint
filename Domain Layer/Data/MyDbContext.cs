using Domain_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {

        }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Complaint> Complaints { get; set; } = null!;
        public DbSet<Demand> Demands { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=LowSuitComplaint;Trusted_Connection=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Complaint>().HasMany<Demand>().WithOne(d => d.Complaint).HasForeignKey(d => d.ComplaintId).HasConstraintName("FK__Complaint__Demand");
            modelBuilder.Entity<User>().HasMany<Complaint>().WithOne(d => d.User).HasForeignKey(d=>d.UserId).HasConstraintName("FK__User__Complaint");
        }
    }
}
