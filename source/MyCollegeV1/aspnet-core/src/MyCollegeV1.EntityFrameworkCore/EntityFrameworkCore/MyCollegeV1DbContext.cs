using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyCollegeV1.Authorization.Roles;
using MyCollegeV1.Authorization.Users;
using MyCollegeV1.MultiTenancy;

namespace MyCollegeV1.EntityFrameworkCore
{
    public class MyCollegeV1DbContext : AbpZeroDbContext<Tenant, Role, User, MyCollegeV1DbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MyCollegeV1DbContext(DbContextOptions<MyCollegeV1DbContext> options)
            : base(options)
        {
        }
    }
}
