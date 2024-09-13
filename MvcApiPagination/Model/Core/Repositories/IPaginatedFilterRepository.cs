using MvcApiPagination.Core.Pagination;

namespace MvcApiPagination.Model.Core.Repositories
{
    public interface IPaginatedFilterRepository<T>
    {
        Task<ResponsePagination<T>> PaginatedSearch(PaginationRequestFilter<T> requestFilter);
    }
}
