using Questao5.Domain.Entities.UserCase;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Database.Context;

namespace Questao5.Infrastructure.Database.Repositories
{
    public class IdempotenciaRepository : IIdempotenciaRepository
    {
        private DbContextConfig _dbContextConfig;
        public IdempotenciaRepository(DbContextConfig dbContextConfig)
        {
            _dbContextConfig = dbContextConfig;
        }
        public void CadastrarIdempotencia(Idempotencia idempotencia)
        {
            _dbContextConfig.Idempotencia.Add(idempotencia);
            _dbContextConfig.SaveChangesAsync();
        }

        public async Task<bool> ValidarIdempotenciaExistente(Guid idempotencia)
        {
            var idempotenciaExiste =  _dbContextConfig.Idempotencia.Where(x => x.ChaveIdempotencia == idempotencia).AsQueryable();

            return idempotenciaExiste.Any();
        }
    }
}
