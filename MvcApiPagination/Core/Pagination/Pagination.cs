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

        public Pagination(int total, int page, int perPage)
        {
            int lastPage = (int)Math.Ceiling((double)total / perPage);
            int currentPage = page;
            int from = (page -1) * perPage + 1;
            int to = (page * perPage);

            From = from;
            To = to;
            PerPage = perPage;
            CurrentPage = currentPage;
            LastPage = lastPage;
            Total = total;
        }

        public Pagination(Pagination pagination)
        {
            From = pagination.From;
            To = pagination.To;
            PerPage = pagination.PerPage;
            CurrentPage = pagination.CurrentPage;
            LastPage = pagination.LastPage;
            Total = pagination.Total;
        }
    }
}
