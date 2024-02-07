using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCollegeV2.Authorization;

namespace MyCollegeV2
{
    [DependsOn(
        typeof(MyCollegeV2CoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyCollegeV2ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyCollegeV2AuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyCollegeV2ApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
