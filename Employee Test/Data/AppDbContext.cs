using Employee_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Test.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Insert these values  to db at migration time
            modelBuilder.Entity<TblAppLangMaster>().HasData(

                new TblAppLangMaster
                {
                    LangCode = "en",
                    LangName = "English",
                    IsDefault = true,
                },
                 new TblAppLangMaster
                 {
                     LangCode = "ar",
                     LangName = "Arabic",
                     IsDefault = false,
                 },
            new TblAppLangMaster
            {
                LangCode = "bn",
                LangName = "Bengali",
                IsDefault = false,
            });

            modelBuilder.Entity<TblCountry>(
                x =>
                {
                    x.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
                    x.Property(u => u.CreatedAt).HasDefaultValueSql("getutcdate()");
                    x.HasIndex(u => new { u.CreatedAt });

                });
            modelBuilder.Entity<TblCountryTran>(
                b =>
                {
                    b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
                    b.HasKey(u => new { u.Id,u.CountryId, u.LangCode });
                    b.HasIndex(u => new {  u.CountryId, u.LangCode }).IsUnique();
                });
        }   

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeDepartmentMapping> EmployeeDepartmentMapping { get; set; }

        public DbSet<TblAppLangMaster>? TblAppLangMaster { get; set; }
        public DbSet<TblCountry>? TblCountries { get; set; }
        public DbSet<TblCountryTran> TblCountryTrans { get; set; }
    }
}
