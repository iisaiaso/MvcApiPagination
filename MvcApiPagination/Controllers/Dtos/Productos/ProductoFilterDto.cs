namespace MvcApiPagination.Controllers.Dtos.Productos
{
    public class ProductoFilterDto
    {
        public string Nombre { get; set; } = default!;
        public double Precio { get; set; }
    }
}
