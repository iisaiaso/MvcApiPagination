using MvcApiPagination.Controllers.Dtos.Fabricantes;
using MvcApiPagination.Model.Core.Model;

namespace MvcApiPagination.Controllers.Dtos.Productos
{
    public class ProductoDto : CoreModel
    {
        public string Nombre { get; set; } = default!;
        public double Precio { get; set; }
        public int IdFabricante { get; set; }
        public FabricanteSimpleDto? Fabricante { get; set; }
    }
}
