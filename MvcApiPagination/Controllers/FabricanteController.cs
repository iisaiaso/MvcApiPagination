using Microsoft.AspNetCore.Mvc;
using MvcApiPagination.Controllers.Dtos.Fabricantes;
using MvcApiPagination.Controllers.Dtos.Productos;
using MvcApiPagination.Model.Entity;
using MvcApiPagination.Model.Repositories;

namespace MvcApiPagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricanteController : ControllerBase
    {
        private readonly IFabricanteRepository _fabricanteRepository;

        public FabricanteController(IFabricanteRepository fabricanteRepository)
        {
            _fabricanteRepository = fabricanteRepository;
        }

        [HttpGet]
        public async Task<IReadOnlyList<FabricanteDto>> Get()
        {
            IReadOnlyList<Fabricante> fabricantes = await _fabricanteRepository.FindAllAsync();
            var response = fabricantes.Select(f => new FabricanteDto
            {
                Id = f.Id,
                Nombre = f.Nombre,
                Productos = f.Productos == null 
                ? null : f.Productos.Select(p => new ProductoSimpleDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                }).ToList()  
            }).ToList();

            return response;
        }
    }
}
