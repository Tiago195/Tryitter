using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Tryitter.DTO;

public class userUpdate
{
  [EmailAddress]
  public string Email { get; set; }
  [MinLength(6)]
  public string Password { get; set; }
  [MinLength(2)]
  public string Name { get; set; }
}
