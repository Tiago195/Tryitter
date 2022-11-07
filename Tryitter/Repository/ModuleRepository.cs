using Tryitter.Model;
using Tryitter.DTO;

namespace Tryitter.Repository;

public class ModuleRepository : IModuleRepository
{
  private readonly ITryitterContext _context;

  public ModuleRepository(ITryitterContext context)
  {
    _context = context;
  }
  public IEnumerable<ModuloModel> GetAll()
  {
    return _context.modulos;
  }

}