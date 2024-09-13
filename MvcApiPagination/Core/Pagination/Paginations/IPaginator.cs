using MvcApiPagination.Core.Pagination;

namespace MvcApiPagination.Core.Paginations.Paginator
{
    public interface IPaginator<T>
    {
        Task<ResponsePagination<T>> Paginate(IQueryable<T> query, PaginationRequest request);
        Task<ResponsePagination<T>> PaginateFilter(IQueryable<T> query, PaginationRequestFilter<T> requestFilter);
    }
}
