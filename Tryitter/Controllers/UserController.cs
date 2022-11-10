using Microsoft.AspNetCore.Mvc;
using Tryitter.Repository;
using Tryitter.DTO;
using Tryitter.Services;
using Microsoft.AspNetCore.Authorization;
using Tryitter.Views;

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
  [Route("{arroba}")]
  public ActionResult GetByArroba(string arroba)
  {
    var user = _repository.GetByArroba(arroba);
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
  public ActionResult Create(UserDto user)
  {
    var getUser = _repository.Create(user);

    var token = Token.Generate(getUser);

    return Created("token", token);
  }

  [HttpPost]
  [Route("/login")]
  public ActionResult Login(UserLoginDto login)
  {
    var user = _repository.Login(login);

    var token = Token.Generate(user);

    return Ok(new { token, user });
  }

  [HttpPut]
  [Route("{id}")]
  [Authorize]
  public ActionResult Update(int id, UserDto user)
  {

    if (HttpContext.User.HasClaim("Id", id.ToString())) return Ok(_repository.Update(id, user));

    return Unauthorized();

  }

  [HttpDelete]
  [Route("{id}")]
  [Authorize]
  // essa rota so funciona se os nao tiverem post
  public ActionResult Delete(int id)
  {
    if (HttpContext.User.HasClaim("Id", id.ToString()))
    {
      _repository.Delete(id);
      return NoContent();
    }
    return Unauthorized();

  }
}