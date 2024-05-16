using Microsoft.EntityFrameworkCore;
using Model;

namespace Method;

public class DBConfig(IConfiguration configuration) : DbContext
{
    public virtual DbSet<UserModel> Users { get; set; }
    public virtual DbSet<Weather> Weathers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#if DEBUG
        optionsBuilder.UseSqlite(configuration.GetConnectionString("Sqlite"));
#else
        optionsBuilder.UseSqlite(configuration.GetConnectionString("Sqlite"));
#endif
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}