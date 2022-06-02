using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Contex
{
    public class MyContext : DbContext
    {
        public MyContext (DbContextOptions<MyContext> options) : base(options)
        {

        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasOne(acc => acc.account)
            .WithOne(emp => emp.employee)
            .HasForeignKey<Account>(acc => acc.NIK);

            modelBuilder.Entity<Account>()
                .HasOne(prof => prof.profiling)
                .WithOne(acc => acc.account)
                .HasForeignKey<Profiling>(prof => prof.NIK);

            modelBuilder.Entity<Education>()
                .HasMany(prof => prof.profiling)
                .WithOne(edu => edu.education);
                
                


            modelBuilder.Entity<University>()
                .HasMany(edu => edu.educations)
                .WithOne(uni => uni.university);
                


        }
        


        public DbSet<Employee> Employees { set; get; }
        public DbSet<Account> Accounts { set;get; }
        public DbSet<Profiling> Profilings { set; get; }
        public DbSet<Education> Education { set; get; }
        public DbSet<University> University { set; get; }
       
    }
}
