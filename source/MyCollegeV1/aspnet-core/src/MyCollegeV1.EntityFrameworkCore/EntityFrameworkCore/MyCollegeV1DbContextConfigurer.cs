using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyCollegeV1.EntityFrameworkCore
{
    public static class MyCollegeV1DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyCollegeV1DbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyCollegeV1DbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
