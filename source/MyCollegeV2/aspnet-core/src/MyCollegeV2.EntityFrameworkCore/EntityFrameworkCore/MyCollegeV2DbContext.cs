using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyCollegeV2.Authorization.Roles;
using MyCollegeV2.Authorization.Users;
using MyCollegeV2.MultiTenancy;

namespace MyCollegeV2.EntityFrameworkCore
{
    public class MyCollegeV2DbContext : AbpZeroDbContext<Tenant, Role, User, MyCollegeV2DbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MyCollegeV2DbContext(DbContextOptions<MyCollegeV2DbContext> options)
            : base(options)
        {
        }
    }
}
