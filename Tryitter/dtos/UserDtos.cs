using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Tryitter.Model;

namespace Tryitter.DTO;

public class UserDto
{
  [EmailAddress]
  public string Email { get; set; }
  [MinLength(6)]
  public string Password { get; set; }
  [MinLength(2)]
  public string Name { get; set; }
  public string Arroba { get; set; }
  public int ModuloId { get; set; }
  public string? Img { get; set; }

}

public class UserLoginDto
{
  [EmailAddress]
  public string Email { get; set; }
  [MinLength(6)]
  public string Password { get; set; }
}

// public class UserSubscriptionDto
// {
//   [EmailAddress]
//   public string Email { get; set; }
//   public string Arroba { get; set; }
//   [MinLength(6)]
//   public string Password { get; set; }
//   public string Name { get; set; }
//   public int ModuloId { get; set; }
// }