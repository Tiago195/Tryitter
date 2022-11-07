using Microsoft.AspNetCore.Mvc;
using Tryitter.Repository;
using Tryitter.Model;
// using Tryitter.DTO;
using Tryitter.Services;
using Microsoft.AspNetCore.Authorization;

namespace Tryitter.Controllers;

[PostController]
[Route("[controller]")]
public class PostController : Controller
{
  private readonly IUserRepository _repository;

  public PostController(IUserRepository repository)
  {
    _repository = repository;
  }

  [HttpGet]
  [Route("{id}")]
  public ActionResult GetById(int id)
  {
    var post = _repository.GetById(id);
    if (post == null) return NotFound(new { message = "Post not found" });

    return Ok(post);
  }

  [HttpGet]
  public ActionResult GetAll()
  {
    var allPosts = _repository.GetAll();

    return Ok(allPosts);
  }

  [HttpGet]
  [Route("{email}")] /* Verificar se é essa a rota, se faz sentido */
  public ActionResult GetAllByEmail(string email)
  {
    var allUserPosts = _repository.GetAllByEmail(email);
    if (post == null) return NotFound(new { message = "User doesn't have any posts (yet!)" });

    return Ok(allUserPosts);
  }

  [HttpPost]
  public ActionResult Create(string post)
  {
    // Try..catch aqui?
    _repository.Create(post);
    return Ok(post);
  }

  [HttpPut]
  [Route("{id}")]
  // [Authorize] ?
  public ActionResult Update(int id, string post)
  {
    // Try..catch aqui? Temos verificação no Repo dessa rota
    _repository.Update(id, post);
    return Ok(post);
  }

  [HttpDelete]
  [Route("{id}")]
  // [Authorize] ?
  public ActionResult Delete(int id)
  {
    _repository.Delete(id);

    return NoContent();
  }
}