using Microsoft.EntityFrameworkCore;
using TendaServicios.Api.Libro.Modelo;

namespace TendaServicios.Api.Libro.Persistencia
{
    public class ContextoLibreria : DbContext
    {
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options)
        {

        }

        public DbSet<LibreriaMaterial> LibreriasMaterial { get; set; }
    }
}
