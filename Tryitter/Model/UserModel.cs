using System.ComponentModel.DataAnnotations;

namespace Tryitter.Model;

public class UserModel
{
  [Key]
  public int UserId { get; set; }
  [EmailAddress]
  public string Email { get; set; }
  [MinLength(6)]
  public string Password { get; set; }
  public string Name { get; set; }
  public ICollection<PostModel>? Posts { get; set; }
}