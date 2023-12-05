using MediatR;

namespace gurusoft_backend.Application.Features.EntradaSalidaPatron.Queries.GetPatronSalida
{
    public class GetPatronSalidaCommand : IRequest<string>
    {
        public string? Entrada { get; set; }
    }
}
