using System.ComponentModel.DataAnnotations;

namespace Tryitter.Model;

public class LikeModel
{
  [Key]
  public int UserId { get; set; }
  [Key]
  public int PostId { get; set; }
}