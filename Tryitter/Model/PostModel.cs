using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Model;

public class PostModel
{
  [Key]
  public int PostId { get; set; }
  public string Content { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.Now;

  public int Likes { get; set; } = 0;
  // [ForeignKey("UserId")]
  public UserModel? User { get; set; } = new UserModel();
}