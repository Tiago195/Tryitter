using Tryitter.Model;

namespace Tryitter.Test;

public static class Helpers
{
  public static List<UserModel> GetUsers() => new()
  {
    new UserModel {
      Email = "user1@gmail.com",
      Password = "123321",
      Name = "userOne",
      Arroba = "One",
      CreatedAt = DateTime.Now,
      Img = "fake image",
      Modulo =  new ModuloModel
        {
          Name = "Fundamentos"
        },
    },
    new UserModel {
      Email = "user2@gmail.com",
      Password = "123456",
      Name = "userTwo",
      Arroba = "Two",
      CreatedAt = DateTime.Now,
      Img = "fake image",
      Modulo =  new ModuloModel
        {
          Name = "Fundamentos"
        },
    },
    // new UserModel {Email = "userTwo@email.com", Password = "123456", Name = "userTwo"},
  };
  // public static List<ModuloModel> GetModulos() => new()
  // {
  //       new ModuloModel
  //       {
  //         // ModuloId = 2,
  //         Name = "Front-end"
  //       },
  //       new ModuloModel
  //       {
  //         // ModuloId = 3,
  //         Name = "Back-end"
  //       },
  //       new ModuloModel
  //       {
  //         // ModuloId = 4,
  //         Name = "Ciência da Computação"
  //       }
  // };
}