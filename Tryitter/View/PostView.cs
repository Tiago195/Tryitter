using Tryitter.Model;
using Tryitter.Entity;

namespace Tryitter.Views;

public class PostView : Post
{
  public virtual User? User { get; set; } = new User();

  static public User ConvertUserModel(UserModel user, ModuloModel modulo)
  {
    return new User()
    {
      Arroba = user.Arroba,
      CreatedAt = user.CreatedAt,
      Email = user.Email,
      Img = user.Img,
      Modulo = modulo,
      Name = user.Name,
      UserId = user.UserId
    };
  }
}