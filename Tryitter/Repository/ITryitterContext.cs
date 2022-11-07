using Microsoft.EntityFrameworkCore;
using Tryitter.Model;

namespace Tryitter.Repository
{
  public interface ITryitterContext
  {
    public DbSet<UserModel> users { get; set; }
    public DbSet<PostModel> posts { get; set; }
    public DbSet<ModuloModel> modulos { get; set; }
    public int SaveChanges();
    // public 
  }
}

