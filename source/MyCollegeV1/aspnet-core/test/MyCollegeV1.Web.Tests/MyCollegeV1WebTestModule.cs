using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCollegeV1.EntityFrameworkCore;
using MyCollegeV1.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MyCollegeV1.Web.Tests
{
    [DependsOn(
        typeof(MyCollegeV1WebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MyCollegeV1WebTestModule : AbpModule
    {
        public MyCollegeV1WebTestModule(MyCollegeV1EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyCollegeV1WebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MyCollegeV1WebMvcModule).Assembly);
        }
    }
}