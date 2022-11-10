using Tryitter.Model;
using Tryitter.DTO;
using RestSharp;
using System.Text.Json;
using Tryitter.Views;
using Tryitter.Services;

namespace Tryitter.Repository;

public class UserRepository : IUserRepository
{
  private readonly ITryitterContext _context;

  public UserRepository(ITryitterContext context)
  {
    _context = context;
  }
  public IEnumerable<UserView> GetAll()
  {
    return (
      from user in _context.users
      select new UserView()
      {
        UserId = user.UserId,
        Email = user.Email,
        Img = user.Img,
        Modulo = user.Modulo,
        Arroba = user.Arroba,
        CreatedAt = user.CreatedAt,
        Name = user.Name,
        Posts = UserView.ConvertPostsModel(user.Posts)
      }
    );
  }

  public UserView Login(UserLoginDto login)
  {
    var user = (
      from u in _context.users
      where u.Email == login.Email && u.Password == login.Password
      select new UserView()
      {
        Arroba = u.Arroba,
        CreatedAt = u.CreatedAt,
        Email = u.Email,
        Img = u.Img,
        Modulo = u.Modulo,
        Name = u.Name,
        UserId = u.UserId
      }
    ).FirstOrDefault();
    if (user == null) throw new InvalidOperationException("Invalid Fields");

    return user;
  }

  public UserView? GetByArroba(string arroba)
  {
    return (
      from user in _context.users
      where user.Arroba == arroba
      select new UserView()
      {
        Arroba = user.Arroba,
        CreatedAt = user.CreatedAt,
        Email = user.Email,
        Img = user.Img,
        Modulo = user.Modulo,
        Name = user.Name,
        Posts = UserView.ConvertPostsModel(user.Posts),
        UserId = user.UserId
      }
      ).First();
  }

  public UserView Create(UserDto userDto)
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

    return new UserView()
    {
      Arroba = newUser.Arroba,
      CreatedAt = newUser.CreatedAt,
      Email = newUser.Email,
      Img = newUser.Img,
      Modulo = newUser.Modulo,
      Name = newUser.Name,
      UserId = newUser.UserId
    };
  }

  public UserView Update(int id, UserDto userUpdate)
  {
    var user = _context.users.Find(id);
    var isExistEmail = _context.users.FirstOrDefault(user => user.Email == userUpdate.Email && user.UserId != id);
    var isExistArroba = _context.users.FirstOrDefault(user => user.Arroba == userUpdate.Arroba && user.UserId != id);

    if (isExistEmail != null) throw new ArgumentException("Already in use", $"Email = {userUpdate.Email}");
    if (isExistArroba != null) throw new ArgumentException("Already in use", $"Arroba = {userUpdate.Arroba}");
    if (user == null) throw new ArgumentNullException($"UserId = {id}", "Not found");

    if (user.Img != userUpdate.Img)
    {
      var response = Image.sendImg(userUpdate.Img);

      user.Img = response.data.link;
    }

    var modulo = _context.modulos.Find(userUpdate.ModuloId);
    user.Email = userUpdate.Email;
    user.Password = userUpdate.Password;
    user.Name = userUpdate.Name;
    user.Arroba = userUpdate.Arroba;
    user.Modulo = modulo;

    _context.users.Update(user);

    _context.SaveChanges();

    return new UserView()
    {
      Email = userUpdate.Email,
      Name = userUpdate.Name,
      Arroba = userUpdate.Arroba,
      Modulo = modulo,
      CreatedAt = user.CreatedAt,
      Img = user.Img,
      UserId = user.UserId
    };
  }

  public void Delete(int id)
  {
    var user = _context.users.Find(id);
    if (user == null) throw new ArgumentNullException($"UserId = {id}", "Not found");

    _context.users.Remove(user);
    _context.SaveChanges();
  }
}