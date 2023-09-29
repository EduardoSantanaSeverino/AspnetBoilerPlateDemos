using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyCollegeV1.Configuration;
using MyCollegeV1.Web;

namespace MyCollegeV1.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MyCollegeV1DbContextFactory : IDesignTimeDbContextFactory<MyCollegeV1DbContext>
    {
        public MyCollegeV1DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyCollegeV1DbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyCollegeV1DbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyCollegeV1Consts.ConnectionStringName));

            return new MyCollegeV1DbContext(builder.Options);
        }
    }
}
