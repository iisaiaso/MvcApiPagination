using Microsoft.AspNetCore.Mvc;
using MvcApiPagination.Controllers.Dtos.Fabricantes;
using MvcApiPagination.Controllers.Dtos.Productos;
using MvcApiPagination.Core.Pagination;
using MvcApiPagination.Model.Entity;
using MvcApiPagination.Model.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcApiPagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IReadOnlyList<ProductoDto>> Get()
        {
            IReadOnlyList<Producto> productos = await _productoRepository.FindAllAsync();
            var response = productos.Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                IdFabricante = p.IdFabricante,
                Fabricante = p.Fabricante == null ? null : new FabricanteSimpleDto
                {
                    Id = p.Fabricante.Id,
                    Nombre = p.Fabricante.Nombre,
                }
            }).ToList();

            return response;
        }

        [HttpGet("Paginated")]
        public async Task<ResponsePagination<ProductoDto>> Paginated([FromQuery] PaginationRequest request)
        {
            var response = await _productoRepository.Paginated(request);
            var data = response.Data.Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                IdFabricante = p.IdFabricante,
                Fabricante = p.Fabricante == null ? null : new FabricanteSimpleDto
                {
                    Id = p.Fabricante.Id,
                    Nombre = p.Fabricante.Nombre
                }
            }).ToList();

            return new ResponsePagination<ProductoDto>(response)
            {
                Data = data,
            };
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<ProductoDto>> PaginatedSearch([FromQuery] PaginationRequestFilter<ProductoFilterDto> request)
        {
            var entity = new PaginationRequestFilter<Producto>
            {
                Page = request.Page,
                PerPage = request.PerPage,
                Filter = request.Filter == null ? null : new Producto
                {
                    Nombre = request.Filter.Nombre,
                    Precio = (double)request.Filter.Precio
                }
            };

            var response = await _productoRepository.PaginatedSearch(entity);
            var data = response.Data.Select(p => new ProductoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                IdFabricante = p.IdFabricante,
                Fabricante = p.Fabricante == null ? null : new FabricanteSimpleDto
                {
                    Id = p.Fabricante.Id,
                    Nombre = p.Fabricante.Nombre
                }
            }).ToList();

            return new ResponsePagination<ProductoDto>(response)
            {
                Data = data,
            };

        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
