using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyCollegeV2.EntityFrameworkCore
{
    public static class MyCollegeV2DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyCollegeV2DbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyCollegeV2DbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
