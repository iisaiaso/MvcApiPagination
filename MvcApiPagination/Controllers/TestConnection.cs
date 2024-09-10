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
                return StatusCode(500, "No se pudo establecer la conexi�n a la base de datos.");
            }
            return Ok("Conexi�n exitosa a la base de datos.");

        }

        [HttpGet("Productos")]
        public async Task<IReadOnlyList<Producto>> GetProducto() 
        {
            return await _dbContext.Set<Producto>().AsNoTracking().ToListAsync();
           
        }

        [HttpGet("Fabricantes")]
        public async Task<IReadOnlyList<Fabricante>> Get()
        {
            return await _dbContext.Set<Fabricante>().AsNoTracking().ToListAsync();

        }
    }
}
