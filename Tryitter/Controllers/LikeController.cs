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
  public ActionResult Like([FromRoute] int postId, UserModel user)
  {

    _repository.Like(postId, user);
    return NoContent();

  }
}