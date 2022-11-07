using Tryitter.Model;
using Tryitter.DTO;

namespace Tryitter.Repository;


public interface IUserRepository
{
  public UserModel? GetById(int id);
  public UserModel? GetByEmail(string email);
  public UserModel? GetByArroba(string arroba);
  public IEnumerable<UserModel> GetAll();
  public UserModel Create(UserSubscriptionDto user);
  public void Update(int id, UserUpdateDto user);
  public void Delete(int id);
}