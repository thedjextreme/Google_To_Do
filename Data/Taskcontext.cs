using Google_To_Do.Models;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<zadanie>().ToTable("Task");

        }
    }
}
