namespace Tryitter.Entity;

public class Post
{
  public int PostId { get; set; }
  public string Content { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.Now;

  public int Likes { get; set; }
}