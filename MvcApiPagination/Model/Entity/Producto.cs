using MvcApiPagination.Model.Core.Model;

namespace MvcApiPagination.Model.Entity
{
    public class Producto : CoreModel
    {
        public string Nombre { get; set; } = default!;
        public double Precio { get; set; }
        public int Id_Fabricante { get; set; }   
    }
}
