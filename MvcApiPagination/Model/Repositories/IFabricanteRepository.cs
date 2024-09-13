using MvcApiPagination.Model.Core.Repositories;
using MvcApiPagination.Model.Entity;

namespace MvcApiPagination.Model.Repositories
{
    public interface IFabricanteRepository : ICrudRepository<Fabricante, int>, IPaginatedRepository<Fabricante>
    {
    }
}
