using MvcApiPagination.Model.Core.Model;

namespace MvcApiPagination.Controllers.Dtos.Productos
{
    public class ProductoSimpleDto : CoreModel
    {
        public string Nombre { get; set; } = default!;
    }
}
