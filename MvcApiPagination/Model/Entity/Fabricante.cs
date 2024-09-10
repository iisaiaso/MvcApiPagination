using MvcApiPagination.Model.Core.Model;

namespace MvcApiPagination.Model.Entity
{
    public class Fabricante : CoreModel
    {
        public string Nombre { get; set; } = default!;
        public virtual IList<Producto>? Productos { get; set; }
    }

    public class FabricanteDto : CoreModel
    {
        public string Nombre { get; set; } = default!;
        public List<ProductoSimpleDto>? Productos { get; set; } 
    }

    public class FabricanteSimpleDto : CoreModel
    {
        public string Nombre { get; set; } = default!;
    }
}
