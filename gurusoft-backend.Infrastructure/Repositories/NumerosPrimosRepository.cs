using gurusoft_backend.Application.Contracts;
using gurusoft_backend.Domain;
using gurusoft_backend.Infrastructure.Persistence;

namespace gurusoft_backend.Infrastructure.Repositories
{
    public class NumerosPrimosRepository : RepositoryBase<NumerosPrimos>, INumerosPrimosRepository
    {
        public NumerosPrimosRepository(NumerosPrimosDbContext context) : base(context)
        {
        }
    }
}
