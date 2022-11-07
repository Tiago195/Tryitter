
namespace Tryitter.DTO;

public class ImageDataDto
{
  public string id { get; set; }
  public string title { get; set; }
  public string description { get; set; }
  public string type { get; set; }
  public int width { get; set; }
  public int height { get; set; }
  public string link { get; set; }
}
public class ImageDto
{
  public ImageDataDto data { get; set; }
  public bool success { get; set; }
  public int status { get; set; }
}
