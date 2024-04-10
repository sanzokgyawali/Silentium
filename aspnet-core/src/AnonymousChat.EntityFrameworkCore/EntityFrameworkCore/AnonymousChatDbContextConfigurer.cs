using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AnonymousChat.EntityFrameworkCore
{
    public static class AnonymousChatDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AnonymousChatDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AnonymousChatDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
