using MvcApiPagination.Model.Core.Model;

namespace MvcApiPagination.Controllers.Dtos.Fabricantes
{
    public class FabricanteSimpleDto : CoreModel
    {
        public string Nombre { get; set; } = default!;
    }
}
