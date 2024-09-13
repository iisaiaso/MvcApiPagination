
using Microsoft.EntityFrameworkCore;
using MvcApiPagination.Core.Paginations.Paginator;

namespace MvcApiPagination.Core.Pagination.Paginations
{
    public class Paginator<T> : IPaginator<T>
    {
        public Task<ResponsePagination<T>> Paginate(IQueryable<T> query, PaginationRequest request)
        {
           return Pagination(query, request.Page, request.PerPage);
        }

        public Task<ResponsePagination<T>> PaginateFilter(IQueryable<T> query, PaginationRequestFilter<T> requestFilter)
        {
            return Pagination(query, requestFilter.Page, requestFilter.PerPage);
        }

        private static async Task<ResponsePagination<T>> Pagination(IQueryable<T> query, int page, int perPage)
        {
            var total = await query.CountAsync();
            var pagination = new Pagination(total, page, perPage);
            int sizePage = pagination.PerPage;
            int currentPage = pagination.CurrentPage;
            if (currentPage > 0) currentPage = page - 1;

            var data = await query.Skip(currentPage * sizePage).Take(sizePage).ToListAsync();

            return new ResponsePagination<T>(pagination)
            {
                Data = data
            };

        }
    }
}
