using Microsoft.AspNetCore.Mvc;
using MvcApiPagination.Model.Core.Context;

namespace MvcApiPagination.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IActionResult GetConexio()
        {
            var canConnect = _dbContext.Database.CanConnect();
            if (!canConnect)
            {
                return StatusCode(500, "No se pudo establecer la conexión a la base de datos.");
            }
            return Ok("Conexión exitosa a la base de datos.");

        }
    }
}
