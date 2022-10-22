using Microsoft.EntityFrameworkCore;
using Tryitter.Model;

namespace Tryitter.Repository;
public class TryitterContext : DbContext
{
  public DbSet<UserModel> users { get; set; }
  public DbSet<PostModel> posts { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer(@"
        Server=127.0.0.1;
        Database=tryitter;
        User=SA;
        Password=Password12;
      ");
    }
  }
}