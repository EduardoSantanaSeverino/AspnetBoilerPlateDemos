using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCollegeV2.EntityFrameworkCore;
using MyCollegeV2.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MyCollegeV2.Web.Tests
{
    [DependsOn(
        typeof(MyCollegeV2WebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MyCollegeV2WebTestModule : AbpModule
    {
        public MyCollegeV2WebTestModule(MyCollegeV2EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyCollegeV2WebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MyCollegeV2WebMvcModule).Assembly);
        }
    }
}