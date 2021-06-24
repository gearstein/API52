using API52.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API52.Context
{ //Menghubungkan Aplikasi dengan Database
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        //public static object Employee { get; internal set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profilling> Profillings { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies();
        //}
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //Employee - Account
            modelbuilder.Entity<Employee>()
                .HasOne(c => c.Account)
                .WithOne(e => e.Employee)
                .HasForeignKey<Account>(d => d.NIK);
            //Account - Profilling
            modelbuilder.Entity<Account>()
                .HasOne(c => c.Profilling)
                .WithOne(e => e.Account)
                .HasForeignKey<Profilling>(d => d.NIK);
            //Profilling - Education
            modelbuilder.Entity<Profilling>()
                .HasOne(c => c.Education)
                .WithMany(e => e.Profillings);
            //Education - University
            modelbuilder.Entity<Education>()
                .HasOne(c => c.University)
                .WithMany(e => e.Educations);
            ////Account - AccountRole - Role
            //modelbuilder.Entity<AccountRole>()
            //    .HasKey(ar => new { ar.NIK, ar.RoleID });
            ////AccountRole - Account
            //modelbuilder.Entity<AccountRole>()
            //    .HasOne<Account>(ar => ar.Account)
            //    .WithMany(a => a.AccountRoles)
            //    .HasForeignKey(ar => ar.NIK);
            ////AccountRole - Role
            //modelbuilder.Entity<AccountRole>()
            //    .HasOne<Role>(ar => ar.Role)
            //    .WithMany(a => a.AccountRoles)
            //    .HasForeignKey(ar => ar.RoleID);
            modelbuilder.Entity<Role>().HasMany(a => a.Accounts)
                .WithMany(b => b.Roles).UsingEntity<AccountRole>
                (c => c.HasOne(d => d.Account)
                .WithMany().HasForeignKey(e => e.NIK), f => f.HasOne(g => g.Role)
                .WithMany().HasForeignKey(h => h.RoleID));
            //Conversi String Gender Employee
            modelbuilder.Entity<Employee>()
            .Property(s => s.Gender)
            .HasConversion<string>();
        }
    }
}
