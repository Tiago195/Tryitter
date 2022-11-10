using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tryitter.Views;

namespace Tryitter.Model;

public class PostModel
{
  [Key]
  public int PostId { get; set; }
  public string Content { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.Now;

  public int Likes { get; set; }
  public int UserId { get; set; }
  public virtual UserModel? User { get; set; } = new UserModel();
}