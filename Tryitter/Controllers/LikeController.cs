using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Model;
using Tryitter.Repository;

namespace Tryitter.Controllers;

[ApiController]
[Route("[controller]")]
public class LikeController : Controller
{
  private readonly ILikeRepository _repository;

  public LikeController(ILikeRepository repository)
  {
    _repository = repository;
  }

  [HttpPost]
  [Route("{postId}")]
  [Authorize]
  public ActionResult Like(int postId)
  {
    var userId = HttpContext.User.Claims.First(x => x.Type == "Id").Value;
    System.Console.WriteLine("🔥😁😁😁🔥😁🔥🔥");
    System.Console.WriteLine(userId);
    _repository.Like(postId, int.Parse(userId));
    return NoContent();

  }
}