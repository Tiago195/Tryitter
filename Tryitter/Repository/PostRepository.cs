using Tryitter.Model;
using Tryitter.Views;

namespace Tryitter.Repository;


public class PostRepository : IPostRepository
{
  private readonly ITryitterContext _context;

  public PostRepository(ITryitterContext context)
  {
    _context = context;
  }

  public IEnumerable<PostView> GetAll()
  {
    return (
      from post in _context.posts
      join module in _context.modulos on post.User.Modulo equals module
      orderby post.CreatedAt descending
      select new PostView()
      {
        PostId = post.PostId,
        Content = post.Content,
        Likes = _context.likes.Where(x => x.PostId == post.PostId).Count(),
        User = PostView.ConvertUserModel(post.User, module)
      }
    );
  }
  public PostModel? GetById(int id)
  {
    return _context.posts.Find(id);
  }
  // public IEnumerable<PostModel>? GetAllByEmail(string email)
  // {
  //   return GetAll().Where(posts => posts.User.Email == email); /* Isso aqui é um array */
  //   // corrigir o find da L25
  // }
  public void Create(int userId, PostModel newPost)
  {
    var user = _context.users.Find(userId);
    newPost.User = user;
    _context.posts.Add(newPost);
    _context.SaveChanges();
  }
  // public void Update(int id, string newPostBody)
  // // Verificar se são satisfeitas e/ou necessárias condições e validações
  // {
  //   var post = GetById(id);
  //   if (post == null) throw new ArgumentNullException($"PostId = {id}", "Not found");

  //   // _context.Entry(post).CurrentValues.SetValues(newPostBody);
  //   _context.SaveChanges();
  // }
  public void Delete(int id, int userId)
  {
    var post = GetById(id);
    if (post.UserId != userId) throw new InvalidOperationException("Invalid");
    if (post == null) throw new ArgumentNullException($"PostId = {id}", "Not found");

    _context.posts.Remove(post);
    _context.SaveChanges();
  }
}