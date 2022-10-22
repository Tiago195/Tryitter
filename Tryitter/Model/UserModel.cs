using System.ComponentModel.DataAnnotations;

namespace Tryitter.Model;

public class UserModel
{
  [Key]
  public int UserId { get; set; }
  public string Email { get; set; }
  public string Password { get; set; }
  public string Name { get; set; }
  public ICollection<PostModel>? Posts { get; set; }
}