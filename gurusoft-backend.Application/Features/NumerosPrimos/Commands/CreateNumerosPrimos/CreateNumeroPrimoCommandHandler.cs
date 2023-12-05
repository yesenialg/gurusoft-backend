using gurusoft_backend.Application.Contracts;
using MediatR;

namespace gurusoft_backend.Application.Features.NumerosPrimos.Commands.CreateNumerosPrimos
{

    //PATRÓN: Mediator para la comunicación entre Controllers y Features
    //Además se usa CQRS para separar las lecturas y ediciones.
    public class CreateNumeroPrimoCommandHandler : IRequestHandler<CreateNumeroPrimoCommand, string>
    {
        private readonly INumerosPrimosRepository _repository;

        public CreateNumeroPrimoCommandHandler(INumerosPrimosRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(CreateNumeroPrimoCommand request, CancellationToken cancellationToken)
        {
            string response = EncontrarPrimos(request.NumeroInicial, request.CantidadPrimos);

            var numerosPrimosData = new Domain.NumerosPrimos
            {
                Request = $"NumeroIncial:{request.NumeroInicial}, CantidadPrimos:{request.CantidadPrimos}",
                FechaRequest = DateTime.Now,
                Response = response,
                FechaResponse = DateTime.Now,
                Usuario = request.Usuario
            };
            await _repository.AddAsync(numerosPrimosData);
            return response;
        }

        public string EncontrarPrimos(int numero, int cantidad)
        {
            int revisarNumero = numero;
            int encontrados = 0;
            string response = "Numeros primos: ";

            while (encontrados < cantidad)
            {
                if (EsPrimo(revisarNumero))
                {
                    response = $"{response}{revisarNumero}, ";
                    encontrados++;
                }
                revisarNumero++;
            }
            return response;
        }

        public static bool EsPrimo(int numero)
        {
            if (numero < 2)
            {
                return false;
            }
            //Verifico si es numero es divisible por i, si lo es no es primo
            //Solo va hasta i igual a la raiz cuadrada del numero.
            for (int i = 2; i <= Math.Sqrt(numero); i++)
            {
                if (numero % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
