using MvcApiPagination.Core.Pagination;

namespace MvcApiPagination.Model.Core.Repositories
{
    public interface IPaginatedRepository<T>
    {
        Task<ResponsePagination<T>> Paginated(PaginationRequest request);
        Task<ResponsePagination<T>> PaginatedSearch(PaginationRequestFilter<T> request);
    }
}
