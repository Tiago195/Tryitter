using Microsoft.AspNetCore.Mvc;
using Tryitter.Repository;
using Tryitter.Model;
using Tryitter.DTO;
using Tryitter.Services;
using Microsoft.AspNetCore.Authorization;
using System.Web.Http.Cors;

namespace Tryitter.Controllers;

[ApiController]
[Route("[controller]")]
// [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
public class UserController : Controller
{
  private readonly IUserRepository _repository;

  public UserController(IUserRepository repository)
  {
    _repository = repository;
  }

  [HttpGet]
  [Route("{arroba}")]
  public ActionResult GetById(string arroba)
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
  public ActionResult Create(UserSubscriptionDto user)
  {
    var getUser = _repository.Create(user);

    var token = Token.Generate(getUser);

    return Created("token", token);
  }

  [HttpPost]
  [Route("/login")]
  public ActionResult Login(UserLoginDto user)
  {
    var getUser = _repository.GetByEmail(user.Email);

    if (getUser == null || getUser.Password != user.Password)
    {
      return BadRequest(new { message = "Invalid fields" });
    }
    var token = Token.Generate(getUser);

    return Ok(new { token = token, name = getUser.Name, email = getUser.Email, userId = getUser.UserId, arroba = getUser.Arroba, Img = getUser.Img, Modulo = getUser.Modulo });
  }

  [HttpPut]
  [Route("{id}")]
  [Authorize]
  public ActionResult Update(int id, UserUpdateDto user)
  {

    if (HttpContext.User.HasClaim("Id", id.ToString())) return Ok(_repository.Update(id, user));

    return Unauthorized();

  }

  [HttpDelete]
  [Route("{id}")]
  [Authorize]
  public ActionResult Delete(int id)
  {
    if (HttpContext.User.HasClaim("Id", id.ToString())) _repository.Delete(id);
    else return Unauthorized();

    return NoContent();
  }
}