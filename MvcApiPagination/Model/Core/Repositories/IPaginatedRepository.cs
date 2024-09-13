namespace MvcApiPagination.Model.Core.Repositories
{
    public interface IPaginatedRepository<T> : IPaginatedQueryRepository<T>, IPaginatedFilterRepository<T>
    {
    }
}
