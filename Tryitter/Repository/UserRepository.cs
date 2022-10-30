using Tryitter.Model;
using Tryitter.DTO;

namespace Tryitter.Repository;

public class UserRepository : IUserRepository
{
  private readonly ITryitterContext _context;

  public UserRepository(ITryitterContext context)
  {
    _context = context;
  }
  public IEnumerable<UserModel> GetAll()
  {
    return _context.users;
  }

  public UserModel? GetById(int id)
  {
    return _context.users.Find(id);
  }

  public UserModel? GetByEmail(string email)
  {
    var user = _context.users.FirstOrDefault(user => user.Email == email);

    return user;
  }

  public UserModel? GetByArroba(string arroba)
  {
    var user = _context.users.FirstOrDefault(user => user.Arroba == arroba);

    return user;
  }

  public void Create(UserModel newUser)
  {
    var emailExist = _context.users.FirstOrDefault(user => user.Email == newUser.Email);
    var arrobaExist = _context.users.FirstOrDefault(user => user.Arroba == newUser.Arroba);

    if (emailExist != null) throw new ArgumentException("Already in use", $"Email = {emailExist.Email}");
    if (emailExist != null) throw new ArgumentException("Already in use", $"Arroba = {arrobaExist.Arroba}");

    _context.users.Add(newUser);
    _context.SaveChanges();
  }

  public void Update(int id, UserUpdateDto userUpdate)
  {
    var user = _context.users.Find(id);
    var isExistEmail = _context.users.FirstOrDefault(user => user.Email == userUpdate.Email);

    if (isExistEmail != null) throw new ArgumentException("Already in use", $"Email = {userUpdate.Email}");
    if (user == null) throw new ArgumentNullException($"UserId = {id}", "Not found");

    // _context.Entry(user).CurrentValues.SetValues(userUpdate);
    user.Email = userUpdate.Email;
    user.Name = userUpdate.Name;
    user.Password = userUpdate.Password;

    _context.users.Update(user);

    _context.SaveChanges();
  }
  public void Delete(int id)
  {
    var user = _context.users.Find(id);
    if (user == null) throw new ArgumentNullException($"UserId = {id}", "Not found");

    _context.users.Remove(user);
    _context.SaveChanges();
  }

}