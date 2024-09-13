namespace MvcApiPagination.Core.Pagination
{
    public class Pagination
    {
        public int From { get; set; }
        public int To { get; set; }
        public int PerPage { get; set; }
        public int CurrentPage { get; set; }
        public int LastPage { get; set; }
        public int Total { get; set; }
    }
}
