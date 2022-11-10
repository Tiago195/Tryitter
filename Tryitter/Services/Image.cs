using RestSharp;
using Tryitter.DTO;

namespace Tryitter.Services;

public class Image
{
  static public ImageDto sendImg(string img)
  {
    var options = new RestClientOptions("https://api.imgur.com/3/image")
    {
      Timeout = -1
    };
    var client = new RestClient(options);
    var request = new RestRequest()
    .AddHeader("Authorization", "Client-ID 441d1df3f1a14af")
    .AddParameter("image", img);
    // .AlwaysMultipartFormData = true;
    request.AlwaysMultipartFormData = true;

    return client.Post<ImageDto>(request);
  }
}