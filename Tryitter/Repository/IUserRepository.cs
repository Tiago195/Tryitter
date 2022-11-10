using Tryitter.Model;
using Tryitter.DTO;
using Tryitter.Views;

namespace Tryitter.Repository;


public interface IUserRepository
{
  public UserView Login(UserLoginDto user);
  public UserView? GetByArroba(string arroba);
  public IEnumerable<UserView> GetAll();
  public UserView Create(UserDto user);
  public UserView Update(int id, UserDto user);
  public void Delete(int id);
}