using gurusoft_backend.Application.Features.NumerosPrimos.Commands.CreateNumerosPrimos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace gurusoft_backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumerosPrimosController : ControllerBase
    {
        //PATR�N: Mediator para la comunicaci�n entre Controllers y Features
        //Adem�s se usa CQRS para separar las lecturas y ediciones.
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