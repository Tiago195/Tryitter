using Microsoft.EntityFrameworkCore;
using Tryitter.Model;
using Tryitter.Repository;

namespace Tryitter.Test;

public class TryitterContextTest : DbContext, ITryitterContext
{
  public TryitterContextTest(DbContextOptions<TryitterContextTest> options)
          : base(options)
  { }

  public DbSet<UserModel> users { get; set; }
  public DbSet<PostModel> posts { get; set; }
  public DbSet<ModuloModel> modulos { get; set; }
  public DbSet<LikeModel> likes { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<LikeModel>()
      .HasKey(like => new { like.UserId, like.PostId });
  }
  // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  // {
  //   if (!optionsBuilder.IsConfigured)
  //   {
  //     optionsBuilder.UseSqlServer(@"
  //       Server=127.0.0.1;
  //       Database=tryitter_test;
  //       User=SA;
  //       Password=Password12;
  //     ");
  //   }
  // }

}
