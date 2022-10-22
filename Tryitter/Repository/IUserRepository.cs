using Tryitter.Model;
using Tryitter.DTO;

namespace Tryitter.Repository;


public interface IUserRepository
{
  public UserModel? GetById(int id);
  public IEnumerable<UserModel> GetAll();
  public void Create(UserModel user);

  public void Update(int id, userUpdate user);
  public void Delete(int id);
}