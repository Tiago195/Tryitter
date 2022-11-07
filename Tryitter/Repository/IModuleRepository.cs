using Tryitter.Model;

namespace Tryitter.Repository;

public interface IModuleRepository
{
  IEnumerable<ModuloModel> GetAll();
}
