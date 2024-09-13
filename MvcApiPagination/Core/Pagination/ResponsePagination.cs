namespace MvcApiPagination.Core.Pagination
{
    public class ResponsePagination<T> : Pagination
    {
        public IReadOnlyList<T> Data { get; set; } = new List<T>();
    }
}
