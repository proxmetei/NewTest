namespace NewTest.Context;

using Microsoft.EntityFrameworkCore;

public static class DbContextOptionsFactory
{
    private const string migrationProjectPrefix = "NewTest.Context.Migrations.";

    public static DbContextOptions<MainDbContext> Create(string connStr, bool detailedLogging = false)
    {
        var bldr = new DbContextOptionsBuilder<MainDbContext>();

        Configure(connStr, detailedLogging).Invoke(bldr);

        return bldr.Options;
    }

    public static Action<DbContextOptionsBuilder> Configure(string connStr, bool detailedLogging = false)
    {
        return (bldr) =>
        {
            bldr.UseNpgsql(connStr,
                opts => opts
                .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
                .MigrationsHistoryTable("_migrations")
                .MigrationsAssembly($"{migrationProjectPrefix}PgSql")
                    );
            if (detailedLogging)
            {
                bldr.EnableSensitiveDataLogging();
            }
            bldr.UseLazyLoadingProxies(true);
        };
    }
}