using Microsoft.AspNetCore.Mvc;
using Tryitter.Repository;
using Tryitter.Model;
using Tryitter.DTO;
using Tryitter.Services;
using Microsoft.AspNetCore.Authorization;

namespace Tryitter.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : Controller
{
  private readonly IPostRepository _repository;

  public PostController(IPostRepository repository)
  {
    _repository = repository;
  }

  // [HttpGet]
  // [Route("{id}")]
  // public ActionResult GetById(int id)
  // {
  //   var post = _repository.GetById(id);
  //   if (post == null) return NotFound(new { message = "Post not found" });

  //   return Ok(post);
  // }

  [HttpGet]
  public ActionResult GetAll()
  {
    var allPosts = _repository.GetAll();

    return Ok(allPosts);
  }

  // [HttpGet]
  // [Route("{email}")] /* Verificar se é essa a rota, se faz sentido */
  // public ActionResult GetAllByEmail(string email)
  // {
  //   var allUserPosts = _repository.GetAllByEmail(email);
  //   if (allUserPosts == null) return NotFound(new { message = "User doesn't have any posts (yet!)" });

  //   return Ok(allUserPosts);
  // }

  [HttpPost]
  [Route("{userId}")]
  [Authorize]
  public ActionResult Create(int userId, PostDto postDto)
  {
    if (HttpContext.User.HasClaim("Id", userId.ToString()))
    {
      var post = new PostModel() { Content = postDto.Content };
      _repository.Create(userId, post);
      return NoContent();
    }

    return Unauthorized();
  }

  // [HttpPut]
  // [Route("{id}")]
  // // [Authorize] ?
  // public ActionResult Update(int id, string post)
  // {
  //   // Try..catch aqui? Temos verificação no Repo dessa rota
  //   _repository.Update(id, post);
  //   return Ok(post);
  // }

  [HttpDelete]
  [Route("{id}")]
  [Authorize]
  public ActionResult Delete(int id)
  {
    var userId = HttpContext.User.Claims.First(x => x.Type == "Id").Value;

    _repository.Delete(id, int.Parse(userId));

    return NoContent();
  }
}