using System.ComponentModel;

namespace MvcApiPagination.Core.Pagination
{
    public class RequestPaginacion
    {
        private int _page; 
        private int _perPage;

        [DefaultValue(1)]
        public int Page 
        { 
            get => _page <= 0 ? 1 : _page;
            set => _page = value;   
        }

        [DefaultValue(10)]
        public int PerPage 
        { 
            get => _perPage <= 0 ? 10 : _perPage;
            set => _perPage = value;
        }

    }

    public class PaginationRequest : RequestPaginacion { }

    public class PaginationRequestFilter<T> : RequestPaginacion { public T? Filter { get; set; } }

}
