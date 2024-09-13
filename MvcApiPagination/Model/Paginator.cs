using Azure.Core;
using Microsoft.EntityFrameworkCore;
using MvcApiPagination.Core.Pagination;
using MvcApiPagination.Model.Core.Paginations;

namespace MvcApiPagination.Model
{
    public class Paginator<T> : IPaginator<T>
    {
        public async Task<ResponsePagination<T>> Paginate(IQueryable<T> query, PaginationRequest request)
        {
            return await Paginated(query, request.Page, request.PerPage);
        }

        public async Task<ResponsePagination<T>> PaginateFilter(IQueryable<T> query, PaginationRequestFilter<T> request)
        {
            return await Paginated(query, request.Page, request.PerPage);
        }
        
        private static async Task<ResponsePagination<T>> Paginated(IQueryable<T> query, int page, int perPage)
        {
            var total = await query.CountAsync();

            int lastPage = (int)Math.Ceiling((double)total / perPage);

            int currentPage = page;
            if (currentPage > 0 ) currentPage = page - 1;
            var data = await query.Skip(currentPage * perPage).Take(perPage).ToListAsync();

            return new ResponsePagination<T>
            {
                Data = data,
                From = (page - 1) * perPage + 1 ,
                To = (page * perPage),
                PerPage = perPage,
                CurrentPage = page,
                LastPage = lastPage,
                Total = total,

            };
        }

    }
}
