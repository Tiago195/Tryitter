using Tryitter.Model;
using Tryitter.Entity;

namespace Tryitter.Views;

public class UserView : User
{
  public virtual List<Post>? Posts { get; set; } = new List<Post>();

  static public List<Post> ConvertPostsModel(ICollection<PostModel> post)
  {
    return post.Select(x => new Post()
    {
      Content = x.Content,
      CreatedAt = x.CreatedAt,
      Likes = x.Likes,
      PostId = x.PostId
    }).ToList();
  }

  // static public UserView CreateUserView(UserModel user)
  // {
  //   return new UserView
  //   {
  //     Arroba = user.Arroba,
  //     CreatedAt = user.CreatedAt,
  //     Email = user.Email,
  //     Img = user.Img,
  //     Modulo = user.Modulo,
  //     Name = user.Name,
  //     UserId = user.UserId,
  //     Posts = ConvertPostsModel(user.Posts)
  //   };
  // }

}