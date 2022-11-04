using System.ComponentModel.DataAnnotations;

namespace Tryitter.Model;

public class ModuloModel
{
  [Key]
  public int ModuloId { get; set; }
  public string Name { get; set; }
}