using Tryitter.Model;

namespace Tryitter.Entity;

public class User
{
  public int UserId { get; set; }
  public string Email { get; set; }
  public string Arroba { get; set; }
  // public string Password { get; set; }
  public string Name { get; set; }
  public ModuloModel Modulo { get; set; } = new ModuloModel();
  public string? Img { get; set; }
  public DateTime CreatedAt { get; set; }
}