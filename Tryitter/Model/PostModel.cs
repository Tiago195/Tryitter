using System.ComponentModel.DataAnnotations;

namespace Tryitter.Model;

public class PostModel
{
  [Key]
  public int PostId { get; set; }
  public string Title { get; set; }
  public string Content { get; set; }
  public UserModel User { get; set; }
}