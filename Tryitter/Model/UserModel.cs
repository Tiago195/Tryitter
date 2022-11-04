using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Model;

public class UserModel
{
  [Key]
  public int UserId { get; set; }
  [EmailAddress]
  public string Email { get; set; }
  public string Arroba { get; set; }
  [MinLength(6)]
  public string Password { get; set; }
  public string Name { get; set; }
  public ModuloModel Modulo { get; set; } = new ModuloModel() { ModuloId = 1, Name = "Fundamentos" };
  public string Img { get; set; } = "https://png.pngtree.com/png-vector/20190223/ourmid/pngtree-profile-line-black-icon-png-image_691065.jpg";
  public ICollection<PostModel>? Posts { get; set; } = new List<PostModel>();
  public DateTime CreatedAt { get; set; } = DateTime.Now;
}