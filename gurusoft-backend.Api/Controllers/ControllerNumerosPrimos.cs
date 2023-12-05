using gurusoft_backend.Application.Features.NumerosPrimos.Commands.CreateNumerosPrimos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace gurusoft_backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumerosPrimosController : ControllerBase
    {
        //PATRÓN: Mediator para la comunicación entre Controllers y Features
        //Además se usa CQRS para separar las lecturas y ediciones.
        private readonly IMediator _mediator;

        public NumerosPrimosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateNumerosPrimos")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<string>> CreateNumerosPrimos([FromBody] CreateNumeroPrimoCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}