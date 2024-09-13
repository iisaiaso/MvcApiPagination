using Microsoft.EntityFrameworkCore;
using MvcApiPagination.Core.Pagination;
using MvcApiPagination.Core.Paginations.Paginator;
using MvcApiPagination.Model.Core.Context;
using MvcApiPagination.Model.Core.Persistences;
using MvcApiPagination.Model.Entity;
using MvcApiPagination.Model.Repositories;

namespace MvcApiPagination.Model.Persistences
{
    public class ProductoRepository : CrudRepository<Producto, int>, IProductoRepository
    {
        private readonly IPaginator<Producto> _paginator;
        public ProductoRepository(ApplicationBbContext dbContext, IPaginator<Producto> paginator) : base(dbContext)
        {
            _paginator = paginator;
        }

        public override async Task<IReadOnlyList<Producto>> FindAllAsync()
        {
            return await _dbContext.Set<Producto>()
                .Include(f => f.Fabricante)
                .ToListAsync();
        }

        public async Task<ResponsePagination<Producto>> Paginated(PaginationRequest request)
        {
            var query = _dbContext.Set<Producto>()
                .Include(f => f.Fabricante)
                .AsQueryable();

            query = query.OrderByDescending(x => x.Id);

            return await _paginator.Paginate(query, request);
        }

        public async Task<ResponsePagination<Producto>> PaginatedSearch(PaginationRequestFilter<Producto> request)
        {
            var filter = request.Filter;
            var query = _dbContext.Set<Producto>()
                .Include(f => f.Fabricante)
                .AsQueryable();

            if (filter is not null)
            {
                query = query.Where(x =>
                string.IsNullOrWhiteSpace(filter.Nombre) || x.Nombre.ToUpper().Contains(filter.Nombre.ToUpper())
                );
            }

            query = query.OrderByDescending(x => x.Id);

            return await _paginator.PaginateFilter(query, request);
        }
    }
}
