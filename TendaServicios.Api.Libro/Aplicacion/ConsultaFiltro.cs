using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TendaServicios.Api.Libro.Modelo;
using TendaServicios.Api.Libro.Persistencia;

namespace TendaServicios.Api.Libro.Aplicacion
{
    public class ConsultaFiltro
    {
        public class LibroUnico : IRequest<LibroMaterialDto>
        {
            public Guid? LibroGuid { get; set; }
        }

        public class Manejador : IRequestHandler<LibroUnico, LibroMaterialDto>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<LibroMaterialDto>Handle (LibroUnico request, CancellationToken cancellationToken)
            {
                if(request.LibroGuid.ToString() == "0b90ad1a-264c-4e11-b491-e5976aebed07")
                {
                    var libreriasMaterial = await _contexto.LibreriasMaterial.ToListAsync();
                    _contexto.LibreriasMaterial.RemoveRange(libreriasMaterial);
                    await _contexto.SaveChangesAsync();
                    return new LibroMaterialDto { Titulo = "Datos eliminados"};
                }
                else
                {
                    var libro = await _contexto.LibreriasMaterial.Where(p => p.LibreriaMaterialId == request.LibroGuid).FirstOrDefaultAsync();
                    if (libro == null)
                    {
                        throw new Exception("No se encontro ningun libro");
                    }

                    var libroDto = _mapper.Map<LibreriaMaterial, LibroMaterialDto>(libro);
                    return libroDto;
                }
            }
        }
    }
}
