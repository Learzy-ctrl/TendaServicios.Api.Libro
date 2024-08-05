using FluentValidation;
using MediatR;
using TendaServicios.Api.Libro.Modelo;
using TendaServicios.Api.Libro.Persistencia;

namespace TendaServicios.Api.Libro.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Titulo { get; set; }
            public DateTime? FechaPublicacion { get; set; }
            public string Descripcion { get; set; }
            public double Precio { get; set; }
            public byte[]? Img { get; set; }
            public Guid? AutorLibro { get; set; }
            public int? cuponId { get; set;}
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(p => p.Titulo).NotEmpty();
                RuleFor(p => p.FechaPublicacion).NotEmpty();
                RuleFor(p => p.AutorLibro).NotEmpty();
                RuleFor(p => p.Precio).NotEmpty();
                //RuleFor(p => p.Img).NotEmpty();
                RuleFor(p => p.Descripcion).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly ContextoLibreria _contexto;
            public Manejador(ContextoLibreria contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken)
            {
                var libro = new LibreriaMaterial
                {
                    Titulo = request.Titulo,
                    FechaPublicacion = request.FechaPublicacion,
                    AutorLibro = request.AutorLibro,
                    Precio = request.Precio,
                    Img = request.Img,
                    CuponId = request.cuponId,
                    Descripcion = request.Descripcion
                };
                _contexto.LibreriasMaterial.Add(libro);
                var valor = await _contexto.SaveChangesAsync();
                if(valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el libro");
            }
        }
    }
}
