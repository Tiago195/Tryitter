
using Tryitter.Model;

namespace Tryitter.Repository
{
  public class UserRepository
  {
    private readonly BaseContext _context;
    public UserRepository(BaseContext context)
    {
      _context = context;
    }
    public UserModel? GetUserById(int id)
    {
      return _context.Users.Find(id);
    }
    public IEnumerable<UserModel> GetUsers()
    {
      return _context.Users;
    }
    public UserModel AddUser(UserModel User)
    {
      _context.Users.Add(User);
      _context.SaveChanges();
      return User;
    }
    public UserModel UpdateUser(UserModel User)
    {
      _context.Users.Update(User);
      _context.SaveChanges();
      return User;
    }
    public UserModel DeleteUser(int id)
    {
      var User = _context.Users.Find(id);
      _context.Users.Remove(User);
      _context.SaveChanges();
      return User;
    }
  }
}