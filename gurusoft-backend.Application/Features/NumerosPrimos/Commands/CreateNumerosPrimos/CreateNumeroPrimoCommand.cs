using MediatR;

namespace gurusoft_backend.Application.Features.NumerosPrimos.Commands.CreateNumerosPrimos
{
    public class CreateNumeroPrimoCommand : IRequest<string>
    {
        public int NumeroInicial { get; set; }
        public int CantidadPrimos { get; set; }
        public string Usuario { get; set; }
    }
}
