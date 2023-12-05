using MediatR;
using System;

namespace gurusoft_backend.Application.Features.EntradaSalidaPatron.Queries.GetPatronSalida
{
    //PATRÓN: Mediator para la comunicación entre Controllers y Features
    //Además se usa CQRS para separar las lecturas y ediciones.
    public class GetPatronSalidaCommandHandler : IRequestHandler<GetPatronSalidaCommand, string>
    {
        public Task<string> Handle(GetPatronSalidaCommand request, CancellationToken cancellationToken)
        {
            if(request.Entrada == null || request.Entrada == "")
            {
                return Task.FromResult("");
            }

            char[] arrayCaracteres = request.Entrada.ToCharArray();

            var response = "";

            double modulo = arrayCaracteres.Length % 2;
            double mitad = arrayCaracteres.Length / 2;

            if (modulo == 0) 
            {
                response = $"{arrayCaracteres[(int)mitad - 1]}{arrayCaracteres[(int)mitad]}";
            }
            else
            {
                response = $"{arrayCaracteres[(int)mitad]}";
            }

            var responseTask = Task.FromResult(response);
            return responseTask;
        }
    }
}
