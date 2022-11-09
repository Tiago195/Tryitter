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

  public void Like(int postId, UserModel user)
  {
    var post = _context.posts.Find(postId);
    // System.Console.WriteLine(postId);
    if (post == null) throw new ArgumentNullException($"PostId = {postId}", "Not found");

    var likeExist = _context.likes.Find(user.UserId, postId);

    if (likeExist != null)
    {
      _context.likes.Remove(likeExist);
    }
    else
    {
      _context.likes.Add(new LikeModel { PostId = postId, UserId = user.UserId });
    }
    _context.SaveChanges();
  }
}