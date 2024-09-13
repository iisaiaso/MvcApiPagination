namespace MvcApiPagination.Core.Pagination
{
    public class RequestPaginacion
    {
        private int _page = 1;
        private int _perPage = 10;

        public int Page 
        { 
            get => _page <= 0 ? 1 : _page;
            set => _page = value;   
        }

        public int PerPage 
        { 
            get => _perPage <= 0 ? 10 : _perPage;
            set => _perPage = value;
        }

    }

    public class PaginationRequest : RequestPaginacion { }

    public class PaginationRequestFilter<T> : RequestPaginacion { public T? Filter { get; set; } }

}
