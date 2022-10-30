using System.ComponentModel.DataAnnotations;

namespace Tryitter.Model;

public class UserModel
{
  [Key]
  public int UserId { get; set; }
  [EmailAddress]
  public string Email { get; set; }
  public string Arroba { get; set; }
  [MinLength(6)]
  public string Password { get; set; }
  public string Name { get; set; }
  public ICollection<PostModel>? Posts { get; set; } = new List<PostModel>();
  public DateTime CreatedAt { get; set; } = DateTime.Now;
}