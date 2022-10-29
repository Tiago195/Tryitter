using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Tryitter.Model;

namespace Tryitter.Repository;
public class TryitterContext : DbContext, ITryitterContext
{
  public TryitterContext(DbContextOptions<TryitterContext> options) : base(options)
  {
    try
    {
      var db = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
      if (db != null)
      {
        if (!db.CanConnect()) db.Create();
        if (!db.HasTables()) db.CreateTables();
        // db.EnsureCreated();
      }
    }
    catch (System.Exception e)
    {
      System.Console.WriteLine(e.Message);
    }
  }

  // public TryitterContext() { }

  public DbSet<UserModel> users { get; set; }
  public DbSet<PostModel> posts { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    var DbHost = Environment.GetEnvironmentVariable("DB_HOST");
    var DbName = Environment.GetEnvironmentVariable("DB_NAME");
    var DbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
    var connectionString = $"Data Source={DbHost};Initial Catalog={DbName};User ID=sa;Password={DbPassword}";
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer(connectionString, opt => opt.EnableRetryOnFailure());
    }
  }
}