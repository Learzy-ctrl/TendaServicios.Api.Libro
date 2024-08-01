using AutoMapper;
using TendaServicios.Api.Libro.Modelo;

namespace TendaServicios.Api.Libro.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDto>();
        }
    }
}
