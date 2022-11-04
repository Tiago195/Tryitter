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

  public UserModel Create(UserSubscriptionDto userDto)
  {
    var emailExist = _context.users.FirstOrDefault(user => user.Email == userDto.Email);
    var arrobaExist = _context.users.FirstOrDefault(user => user.Arroba == userDto.Arroba);

    if (emailExist != null) throw new ArgumentException("Already in use", $"Email = {emailExist.Email}");
    if (emailExist != null) throw new ArgumentException("Already in use", $"Arroba = {arrobaExist.Arroba}");

    var newUser = new UserModel()
    {
      Arroba = userDto.Arroba,
      Email = userDto.Email,
      Name = userDto.Name,
      Password = userDto.Password,
      Modulo = _context.modulos.Find(userDto.ModuloId),
    };

    _context.users.Add(newUser);
    _context.SaveChanges();

    return newUser;
  }

  public void Update(int id, UserUpdateDto userUpdate)
  {
    var user = _context.users.Find(id);
    var isExistEmail = _context.users.FirstOrDefault(user => user.Email == userUpdate.Email && user.UserId != id);
    var isExistArroba = _context.users.FirstOrDefault(user => user.Arroba == userUpdate.Arroba && user.UserId != id);

    if (isExistEmail != null) throw new ArgumentException("Already in use", $"Email = {userUpdate.Email}");
    if (isExistArroba != null) throw new ArgumentException("Already in use", $"Arroba = {userUpdate.Arroba}");
    if (user == null) throw new ArgumentNullException($"UserId = {id}", "Not found");

    // _context.Entry(user).CurrentValues.SetValues(userUpdate);
    var modulo = _context.modulos.Find(userUpdate.ModuloId);
    user.Email = userUpdate.Email;
    user.Password = userUpdate.Password;
    user.Name = userUpdate.Name;
    user.Arroba = userUpdate.Arroba;
    user.Modulo = modulo;
    user.Img = userUpdate.Img;

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