namespace MvcApiPagination.Core.Pagination
{
    public class ResponsePagination<T> : Pagination
    {
        public ResponsePagination(int total, int page, int perpage) : base(total, page, perpage)
        {
        }

        public ResponsePagination(Pagination pagination) : base(pagination) { }

        public IReadOnlyList<T> Data { get; set; } = new List<T>();
    }
}
