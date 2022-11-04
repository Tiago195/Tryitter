using Microsoft.AspNetCore.Mvc;
using Tryitter.Repository;

namespace Tryitter.Controllers;

[ApiController]
[Route("[controller]")]
public class ModuleController : Controller
{
  private readonly IModuleRepository _repository;

  public ModuleController(IModuleRepository repository)
  {
    _repository = repository;
  }

  [HttpGet]
  public ActionResult GetAll()
  {
    return Ok(_repository.GetAll());
  }

}