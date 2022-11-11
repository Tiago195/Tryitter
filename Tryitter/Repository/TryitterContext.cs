using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Tryitter.Model;

namespace Tryitter.Repository;
public class TryitterContext : DbContext, ITryitterContext
{
  // public TryitterContext(DbContextOptions<TryitterContext> options) : base(options)
  // {
  //   try
  //   {
  //     var db = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
  //     if (db != null)
  //     {
  //       if (!db.CanConnect()) db.Create();
  //       if (!db.HasTables()) db.CreateTables();
  //       // db.EnsureCreated();
  //     }
  //   }
  //   catch (System.Exception e)
  //   {
  //     System.Console.WriteLine(e.Message);
  //   }
  // }

  // public TryitterContext() { }

  public DbSet<UserModel> users { get; set; }
  public DbSet<PostModel> posts { get; set; }
  public DbSet<ModuloModel> modulos { get; set; }
  public DbSet<LikeModel> likes { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    var DbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "127.0.0.1";
    var DbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "Tryitter";
    var DbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD") ?? "Password12";
    var connectionString = $"Data Source={DbHost};Initial Catalog={DbName};User ID=sa;Password={DbPassword}";
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer(connectionString, opt => opt.EnableRetryOnFailure());
    }
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<LikeModel>()
      .HasKey(like => new { like.UserId, like.PostId });

    modelBuilder.Entity<UserModel>()
      .HasMany(post => post.Posts)
      .WithOne(user => user.User);

    modelBuilder.Entity<PostModel>()
      .HasOne(user => user.User)
      .WithMany(post => post.Posts);

    modelBuilder.Entity<ModuloModel>().HasData(
        new ModuloModel
        {
          ModuloId = 1,
          Name = "Fundamentos"
        },
        new ModuloModel
        {
          ModuloId = 2,
          Name = "Front-end"
        },
        new ModuloModel
        {
          ModuloId = 3,
          Name = "Back-end"
        },
        new ModuloModel
        {
          ModuloId = 4,
          Name = "Ciência da Computação"
        }
    );
  }
}