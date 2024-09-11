using MvcApiPagination.Controllers.Dtos.Productos;
using MvcApiPagination.Model.Core.Model;

namespace MvcApiPagination.Controllers.Dtos.Fabricantes
{
    public class FabricanteDto : CoreModel
    {
        public string Nombre { get; set; } = default!;
        public List<ProductoSimpleDto>? Productos { get; set; }
    }
}
