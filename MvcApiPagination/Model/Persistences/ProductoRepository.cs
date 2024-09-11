using Microsoft.EntityFrameworkCore;
using MvcApiPagination.Model.Core.Context;
using MvcApiPagination.Model.Core.Persistences;
using MvcApiPagination.Model.Entity;
using MvcApiPagination.Model.Repositories;

namespace MvcApiPagination.Model.Persistences
{
    public class ProductoRepository : CrudRepository<Producto, int> ,IProductoRepository
    {
        public ProductoRepository(ApplicationBbContext dbContext) : base(dbContext) 
        {

        }

        public override async Task<IReadOnlyList<Producto>> FindAllAsync()
        {
            return await _dbContext.Set<Producto>()
                .Include(f => f.Fabricante)
                .ToListAsync();
        }

    }
}
