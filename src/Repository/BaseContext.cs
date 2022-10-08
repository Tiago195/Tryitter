using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Tryitter.Model;

namespace Tryitter.Repository;

public class BaseContext : DbContext
{
  public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }

  public virtual DbSet<UserModel> Users { get; set; }
  public virtual DbSet<PostModel> Posts { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=tryitter;User=SA;Password=<YourStrong@Passw0rd>");
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<PostModel>()
      .HasOne(x => x.User)
      .WithMany(x => x.Posts)
      .HasForeignKey(x => x.UserId);
  }
}

public class BaseDbContextFactory : IDesignTimeDbContextFactory<BaseContext>
{
  public BaseContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<BaseContext>();
    optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=tryitter;User=SA;Password=<YourStrong@Passw0rd>");

    return new BaseContext(optionsBuilder.Options);
  }
}