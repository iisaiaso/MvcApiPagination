using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApiPagination.Model.Core.Context;
using MvcApiPagination.Model.Entity;

namespace MvcApiPagination.Controllers
{
    [ApiController]
    // [Route("[controller]")]
    public class TestConnection : ControllerBase
    {
        private readonly ApplicationBbContext _dbContext;
        private readonly ILogger<TestConnection> _logger;

        public TestConnection(ILogger<TestConnection> logger, ApplicationBbContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        [HttpGet("TestConexion")]
        public IActionResult GetConexion()
        {
            var canConnect = _dbContext.Database.CanConnect();
            if (!canConnect)
            {
                return StatusCode(500, "No se pudo establecer la conexión a la base de datos.");
            }
            return Ok("Conexión exitosa a la base de datos.");

        }

        [HttpGet("Productos")]
        public async Task<IReadOnlyList<ProductoDto>> GetProducto()
        {
            return await _dbContext.Set<Producto>()
                .AsNoTracking()
                .Include(x => x.Fabricante)
                .Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Fabricante = p.Fabricante == null ? null : new  FabricanteSimpleDto
                    {
                        Id = p.Fabricante.Id,
                        Nombre = p.Fabricante.Nombre,
                    }
                })
                .ToListAsync();
        }

        [HttpGet("Fabricantes")]
        public async Task<IReadOnlyList<FabricanteDto>> Get()
        {
            return await _dbContext.Set<Fabricante>()
                .AsNoTracking()
                .Include(x => x.Productos)
                .Select(f => new FabricanteDto
                {
                    Id = f.Id,
                    Nombre = f.Nombre,
                    Productos = f.Productos != null
                    ? f.Productos.Select(p => new ProductoSimpleDto
                    {
                        Id = p.Id,
                        Nombre = p.Nombre,
                    }).ToList() : new List<ProductoSimpleDto>()
                })
                .ToListAsync();

        }
    }
}
