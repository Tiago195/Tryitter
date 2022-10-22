using Microsoft.AspNetCore.Mvc;
using Tryitter.Repository;
using Tryitter.Model;
using Tryitter.DTO;

namespace Tryitter.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
  private readonly IUserRepository _repository;

  public UserController(IUserRepository repository)
  {
    _repository = repository;
  }

  [HttpGet]
  [Route("{id}")]
  public ActionResult GetById(int id)
  {
    var user = _repository.GetById(id);
    if (user == null) return NotFound(new { message = "User not found" });

    return Ok(user);
  }

  [HttpGet]
  public ActionResult GetAll()
  {
    var users = _repository.GetAll();

    return Ok(users);
  }

  [HttpPost]
  public ActionResult Create(UserModel user)
  {
    _repository.Create(user);

    return Ok(user);
  }

  [HttpPut]
  [Route("{id}")]
  public ActionResult Update(int id, userUpdate user)
  {
    _repository.Update(id, user);

    return Ok(user);
  }

  [HttpDelete]
  [Route("{id}")]
  public ActionResult Delete(int id)
  {
    _repository.Delete(id);

    return NoContent();
  }

}