using Tryitter.Model;

namespace Tryitter.Repository;


public class PostRepository: IPostRepository
{
  private readonly TryitterContext _context;

  public PostRepository(TryitterContext context)
  {
    _context = context;
  }

  public IEnumerable<PostModel> GetAll()
  {
    return _context.posts;
  }
  public PostModel? GetById(int id)
  {
    return _context.posts.Find(id);
  }
  public IEnumerable<PostModel>? GetAllByEmail(string email)
  {
    return _context.posts.Where(posts => posts.User.Email == email); /* Isso aqui é um array */
    // corrigir o find da L25
  }
  public void Create(PostModel newPost)
  // Verificar se não está faltando algum check
  {
    _context.posts.Add(newPost);
    _context.SaveChanges();
  }
  public void Update(int id, string newPostBody)
  // Verificar se são satisfeitas e/ou necessárias condições e validações
  {
    var post = GetById(id);
    if (post == null) throw new ArgumentNullException($"PostId = {id}", "Not found");

    // _context.Entry(post).CurrentValues.SetValues(newPostBody);
    _context.SaveChanges();
  }
  public void Delete(int id)
  {
    var post = GetById(id);
    if (post == null) throw new ArgumentNullException($"PostId = {id}", "Not found");

    _context.posts.Remove(post);
    _context.SaveChanges();
  }
}