using MvcApiPagination.Model.Core.Repositories;
using MvcApiPagination.Model.Entity;

namespace MvcApiPagination.Model.Repositories
{
    public interface IProductoRepository : ICrudRepository<Producto, int>, IPaginatedRepository<Producto>
    {
    }
}
