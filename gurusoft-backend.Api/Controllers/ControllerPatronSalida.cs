using gurusoft_backend.Application.Features.EntradaSalidaPatron.Queries.GetPatronSalida;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace gurusoft_backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatronSalidaController : ControllerBase
    {
        //PATRÓN: Mediator para la comunicación entre Controllers y Features
        //Además se usa CQRS para separar las lecturas y ediciones.
        private readonly IMediator _mediator;

        public PatronSalidaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetPatronSalida")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<string>> CreatePatronSalida([FromBody] GetPatronSalidaCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}