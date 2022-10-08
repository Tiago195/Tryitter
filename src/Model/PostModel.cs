using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Model;

public class PostModel
{
  [Key]
  public int PostId { get; set; }
  public string Title { get; set; }
  public string Content { get; set; }
  [ForeignKey("UserId")]
  public int UserId { get; set; }
  public virtual UserModel User { get; set; }
}