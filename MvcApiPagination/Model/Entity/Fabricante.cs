using MvcApiPagination.Model.Core.Model;

namespace MvcApiPagination.Model.Entity
{
    public class Fabricante : CoreModel
    {
        public string Nombre { get; set; } = default!;
        public virtual IList<Producto>? Productos { get; set; }
    }
}
