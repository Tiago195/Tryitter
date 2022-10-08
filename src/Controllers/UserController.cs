using Microsoft.AspNetCore.Mvc;
using Tryitter.Repository;
using Tryitter.Model;

namespace Tryitter.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  public UserRepository _context;

  public UserController(UserRepository context)
  {
    _context = context;
  }

  [HttpGet]
  public ActionResult Get()
  {
    var users = _context.GetUsers();

    return Ok(users);
  }

  [HttpGet("{Id}")]
  public ActionResult GetUserById(int Id)
  {
    var user = _context.GetUserById(Id);

    if (user == null) return NotFound();

    return Ok(user);
  }

  [HttpPost]
  public ActionResult AddUser(UserModel User)
  {
    var createUser = _context.AddUser(User);

    return CreatedAtRoute("done", createUser);
  }

  [HttpPut]
  public ActionResult UpdateUser(UserModel User)
  {
    var user = _context.GetUserById(User.UserId);
    if (user == null) return BadRequest();

    _context.UpdateUser(User);

    return NoContent();
  }

  [HttpDelete("{Id}")]
  public ActionResult DeleteUser(int Id)
  {
    var user = _context.GetUserById(Id);
    if (user == null) return BadRequest();

    _context.DeleteUser(Id);
    return NoContent();
  }
}
