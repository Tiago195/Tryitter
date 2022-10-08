
using Tryitter.Model;

namespace Tryitter.Repository
{
  public class PostRepository
  {
    private readonly BaseContext _context;
    public PostRepository(BaseContext context)
    {
      _context = context;
    }
    public PostModel? GetPostById(int id)
    {
      return _context.Posts.Find(id);
    }
    public IEnumerable<PostModel> GetPosts()
    {
      return _context.Posts;
    }
    public PostModel AddPost(PostModel post)
    {
      _context.Posts.Add(post);
      _context.SaveChanges();
      return post;
    }
    public PostModel UpdatePost(PostModel post)
    {
      _context.Posts.Update(post);
      _context.SaveChanges();
      return post;
    }
    public PostModel DeletePost(int id)
    {
      var Post = _context.Posts.Find(id);
      _context.Posts.Remove(Post);
      _context.SaveChanges();
      return Post;
    }
  }
}