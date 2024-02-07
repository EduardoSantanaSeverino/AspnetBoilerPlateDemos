using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyCollegeV2.Authorization.Roles;
using MyCollegeV2.Authorization.Users;
using MyCollegeV2.MultiTenancy;
using MyCollegeV2.Models;
///DbContext.cs.place1///

namespace MyCollegeV2.EntityFrameworkCore
{
    public class MyCollegeV2DbContext : AbpZeroDbContext<Tenant, Role, User, MyCollegeV2DbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MyCollegeV2DbContext(DbContextOptions<MyCollegeV2DbContext> options)
            : base(options)
        {
        }

        // add these lines to override max length of property
        // we should set max length smaller than the PostgreSQL allowed size (10485760)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Abp.Localization.ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(100); // any integer that is smaller than 10485760
        }
        public virtual DbSet<Student> Students { get; set; }
///DbContext.cs.place2///
    }
}

