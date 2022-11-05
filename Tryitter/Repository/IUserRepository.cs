using Tryitter.Model;
using Tryitter.DTO;

namespace Tryitter.Repository;


public interface IUserRepository
{
  public UserModel? GetById(int id);
  public UserModel? GetByEmail(string email);
  public IEnumerable<UserModel> GetAll();
  public void Create(UserModel user);
  public void Update(int id, UserUpdateDto user);
  public void Delete(int id);
}