using Microsoft.EntityFrameworkCore;
using MvcApiPagination.Model.Core.Context;
using MvcApiPagination.Model.Core.Persistences;
using MvcApiPagination.Model.Entity;
using MvcApiPagination.Model.Repositories;

namespace MvcApiPagination.Model.Persistences
{
    public class FabricanteRepository : CrudRepository<Fabricante, int>, IFabricanteRepository
    {
        public FabricanteRepository(ApplicationBbContext dbContext) : base(dbContext) 
        {

        }

        public override async Task<IReadOnlyList<Fabricante>> FindAllAsync()
        {
            return await _dbContext.Set<Fabricante>()
                .Include(p => p.Productos)
                .ToListAsync();
        }

    }
}
