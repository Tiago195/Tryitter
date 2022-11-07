using Tryitter.Model;

namespace Tryitter.Test;

public static class Helpers
{
  public static List<UserModel> GetUsers() => new()
  {
    new UserModel {Email = "user1@gmail.com", Password = "123321", Name = "userOne"},
    new UserModel {Email = "userTwo@email.com", Password = "123456", Name = "userTwo"},
  };
}