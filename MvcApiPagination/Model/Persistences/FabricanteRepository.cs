using Microsoft.EntityFrameworkCore;
using MvcApiPagination.Core.Pagination;
using MvcApiPagination.Core.Paginations.Paginator;
using MvcApiPagination.Model.Core.Context;
using MvcApiPagination.Model.Core.Persistences;
using MvcApiPagination.Model.Entity;
using MvcApiPagination.Model.Repositories;

namespace MvcApiPagination.Model.Persistences
{
    public class FabricanteRepository : CrudRepository<Fabricante, int>, IFabricanteRepository
    {
        public readonly IPaginator<Fabricante> _paginator;
        public FabricanteRepository(ApplicationBbContext dbContext, IPaginator<Fabricante> paginator) : base(dbContext)
        {
            _paginator = paginator;
        }

        public override async Task<IReadOnlyList<Fabricante>> FindAllAsync()
        {
            return await _dbContext.Set<Fabricante>()
                .Include(p => p.Productos)
                .ToListAsync();
        }

        public async Task<ResponsePagination<Fabricante>> Paginated(PaginationRequest request)
        {
            var query = _dbContext.Set<Fabricante>()
                .Include(p => p.Productos)
                .AsQueryable();

            query = query.OrderByDescending(x => x.Id);

            return await _paginator.Paginate(query, request);
        }

        public async Task<ResponsePagination<Fabricante>> PaginatedSearch(PaginationRequestFilter<Fabricante> request)
        {
            var filter = request.Filter;

            var query = _dbContext.Set<Fabricante>()
                .Include(p => p.Productos)
                .AsQueryable();

            if(filter is not null)
            {
                query = query.Where(x => string.IsNullOrWhiteSpace(filter.Nombre) || x.Nombre.ToUpper().Contains(filter.Nombre.ToUpper()));
            }

            query = query.OrderByDescending (x => x.Id);

            return await _paginator.PaginateFilter(query, request); 
        }
    }
}
