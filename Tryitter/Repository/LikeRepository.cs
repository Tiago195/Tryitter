using Tryitter.Repository;
using Tryitter.Model;

namespace Tryitter.Repository;

public class LikeRepository : ILikeRepository
{
  private readonly ITryitterContext _context;

  public LikeRepository(ITryitterContext context)
  {
    _context = context;
  }

  public void Like(int postId, int userId)
  {
    var post = _context.posts.Find(postId);
    var user = _context.users.Find(userId);
    // System.Console.WriteLine(postId);
    if (post == null) throw new ArgumentNullException($"PostId = {postId}", "Not found");
    if (user == null) throw new ArgumentNullException($"UserId = {userId}", "Not found");

    var likeExist = _context.likes.Find(userId, postId);

    if (likeExist != null)
    {
      _context.likes.Remove(likeExist);
    }
    else
    {
      _context.likes.Add(new LikeModel { PostId = postId, UserId = userId });
    }
    _context.SaveChanges();
  }
}