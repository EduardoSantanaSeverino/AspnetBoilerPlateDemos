using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyCollegeV2.Configuration;
using MyCollegeV2.Web;

namespace MyCollegeV2.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MyCollegeV2DbContextFactory : IDesignTimeDbContextFactory<MyCollegeV2DbContext>
    {
        public MyCollegeV2DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyCollegeV2DbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyCollegeV2DbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyCollegeV2Consts.ConnectionStringName));

            return new MyCollegeV2DbContext(builder.Options);
        }
    }
}
