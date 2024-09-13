using MvcApiPagination.Core.Pagination;

namespace MvcApiPagination.Model.Core.Repositories
{
    public interface IPaginatedQueryRepository<T>
    {
        Task<ResponsePagination<T>> Paginated(PaginationRequest request);
    }
}
