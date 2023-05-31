using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google_ToDo.Data
{
    public class Taskcontext:DbContext
    {
        public Taskcontext(DbContextOptions<Taskcontext> options) : base(options)
        {

        }
        public DbSet<zadanie> zadanie { get; set; }
        //public virtual DbSet<EmployeeLogin> EmployeeLogin { get; set; }
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //  if (!optionsBuilder.IsConfigured)
        // {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-JI65VED\\SQLEXPRESS;Database=Employee;Trusted_Connection=True;");
        //    }
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<zadanie>().ToTable("Task");

        }
    }
}
