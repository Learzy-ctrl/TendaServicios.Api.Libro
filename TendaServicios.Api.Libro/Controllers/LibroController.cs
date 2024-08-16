using MediatR;
using Microsoft.AspNetCore.Mvc;
using TendaServicios.Api.Libro.Aplicacion;

namespace TendaServicios.Api.Libro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LibroController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<LibroMaterialDto>>> GetLibros()
        {
            return await _mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibroMaterialDto>> GetLibro(string id)
        {
            return await _mediator.Send(new ConsultaFiltro.LibroUnico { LibroGuid = Guid.Parse(id) });
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<Unit>> RemoveBook(string _id)
        {
            return await _mediator.Send(new Eliminar.Ejecuta { Id = Guid.Parse(_id) });
        }
    }
}
