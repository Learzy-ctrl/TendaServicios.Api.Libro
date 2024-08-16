using FluentValidation;
using MediatR;
using TendaServicios.Api.Libro.Persistencia;

namespace TendaServicios.Api.Libro.Aplicacion
{
    public class Eliminar
    {
        public class Ejecuta : IRequest
        {
            public Guid? Id { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(p => p.Id).NotEmpty();
            }
        }

        public class Manejador :IRequestHandler<Ejecuta>
        {
            public readonly ContextoLibreria _contexto;
            public Manejador(ContextoLibreria contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle (Ejecuta request, CancellationToken cancellationToken)
            {
                var libro = await _contexto.LibreriasMaterial.FindAsync(request.Id);
                _contexto.LibreriasMaterial.Remove(libro);
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
