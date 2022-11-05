using Microsoft.AspNetCore.Mvc;
using Tryitter.Repository;
using Tryitter.Model;
using Tryitter.DTO;
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
    
  }
}