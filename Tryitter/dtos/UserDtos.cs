using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Tryitter.DTO;

public class UserUpdateDto
{
  [EmailAddress]
  public string Email { get; set; }
  [MinLength(6)]
  public string Password { get; set; }
  [MinLength(2)]
  public string Name { get; set; }
}

public class UserLoginDto
{
  [EmailAddress]
  public string Email { get; set; }
  [MinLength(6)]
  public string Password { get; set; }
}