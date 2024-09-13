using MvcApiPagination.Core.Pagination;

namespace MvcApiPagination.Model.Core.Paginations
{
    public interface IPaginator<T>
    {
        Task<ResponsePagination<T>> Paginate(IQueryable<T> query, PaginationRequest request);
        Task<ResponsePagination<T>> PaginateFilter(IQueryable<T> query, PaginationRequestFilter<T> request);
    }
}
