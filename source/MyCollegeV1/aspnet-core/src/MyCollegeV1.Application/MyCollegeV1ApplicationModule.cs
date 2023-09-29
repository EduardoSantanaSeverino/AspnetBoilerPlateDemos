using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCollegeV1.Authorization;

namespace MyCollegeV1
{
    [DependsOn(
        typeof(MyCollegeV1CoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyCollegeV1ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyCollegeV1AuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyCollegeV1ApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
