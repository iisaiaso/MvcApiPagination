using Microsoft.AspNetCore.Mvc;
using MvcApiPagination.Controllers.Dtos.Fabricantes;
using MvcApiPagination.Controllers.Dtos.Productos;
using MvcApiPagination.Core.Pagination;
using MvcApiPagination.Model.Entity;
using MvcApiPagination.Model.Persistences;
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

        [HttpGet("Paginated")]
        public async Task<ResponsePagination<FabricanteDto>> Paginated([FromQuery] PaginationRequest request)
        {
            var response = await _fabricanteRepository.Paginated(request);

            // Mapea cada Fabricante a FabricanteDto
            var data = response.Data
                .Select(f => new FabricanteDto
                {
                    Id = f.Id,
                    Nombre = f.Nombre,
                    Productos = f.Productos == null ? null : f.Productos.Select(p => new ProductoSimpleDto
                    {
                        Id= p.Id,
                        Nombre= p.Nombre,   
                    }).ToList(),
                    // Otras propiedades del DTO que quieras mapear
                })
                .ToList();

            // Crear la instancia de ResponsePagination<FabricanteDto> manualmente
            var responsePagination = new ResponsePagination<FabricanteDto>
            {
                Data = data,
                From = response.From,
                To = response.To,
                PerPage = response.PerPage,
                CurrentPage = response.CurrentPage,
                LastPage = response.LastPage,
                Total = response.Total,

            };

            return responsePagination;
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<FabricanteDto>> PaginatedSearch([FromQuery] PaginationRequestFilter<FabricanteFilterDto> request)
        {
            var entity = new PaginationRequestFilter<Fabricante>
            {
                Page = request.Page,
                PerPage = request.PerPage,
                Filter = request.Filter == null ? null : new Fabricante
                {
                    Nombre = request.Filter.Nombre
                }
            };

            var response = await _fabricanteRepository.PaginatedSearch(entity);
            
            var data = response.Data
                .Select(f => new FabricanteDto
                {
                    Id = f.Id,
                    Nombre = f.Nombre,
                    Productos = f.Productos == null ? null
                    : f.Productos.Select(p => new ProductoSimpleDto
                    {
                        Id = p.Id,
                        Nombre = p.Nombre,
                    }).ToList()
                }).ToList();

            var responsePagination = new ResponsePagination<FabricanteDto>
            {
                Data = data,
                From = response.From,
                To = response.To,
                PerPage = response.PerPage,
                CurrentPage = response.CurrentPage,
                LastPage = response.LastPage,
                Total = response.Total,
            };

            return responsePagination;
        }
    }
}
