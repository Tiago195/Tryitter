using Tryitter.Model;
using Tryitter.DTO;

namespace Tryitter.Repository;


public interface IPostRepository
{
  public IEnumerable<PostModel> GetAll();
  public PostModel? GetById(int id);
  public PostModel? GetAllByEmail(string email);
  public void Create(PostModel user);
  public void Update(int id, string postBody); /* Usar dtos?? Acho que n precisa */
  public void Delete(int id);
}