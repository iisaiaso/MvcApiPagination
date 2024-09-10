using Microsoft.EntityFrameworkCore;
using MvcApiPagination.Model.Entity;

namespace MvcApiPagination.Model.Core.Context
{
    public class ApplicationBbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationBbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Fabricante> Fabricante { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DbConnection")
                ?? throw new InvalidOperationException("No se encontro cadena de coneccion"));
            }
        }
    }
}
