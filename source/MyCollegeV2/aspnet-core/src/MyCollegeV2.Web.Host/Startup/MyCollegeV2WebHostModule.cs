using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCollegeV2.Configuration;

namespace MyCollegeV2.Web.Host.Startup
{
    [DependsOn(
       typeof(MyCollegeV2WebCoreModule))]
    public class MyCollegeV2WebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyCollegeV2WebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            System.AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            System.AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            // https://www.npgsql.org/efcore/release-notes/6.0.html?tabs=annotations
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyCollegeV2WebHostModule).GetAssembly());
        }
    }
}
