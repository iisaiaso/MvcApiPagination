namespace MvcApiPagination.Controllers.Dtos.Productos
{
    public class ProductoSaveDto
    {
        public string Nombre { get; set; } = default!;
        public double precio { get; set; }
        public int IdFabricante { get; set; }
    }
}
