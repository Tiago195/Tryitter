using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Tryitter.Model;

public class UserModel
{
  [Key]
  public int UserId { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Password { get; set; }
  // [InverseProperty("UserModel")]
  public ICollection<PostModel>? Posts { get; set; }
}