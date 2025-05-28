using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities.Business;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Database.Context;

namespace Questao5.Infrastructure.Database.Repositories
{
    public class MovimentoRepository : IMovimentoRepository
    {
        private DbContextConfig _dbContextConfig;
        public MovimentoRepository(DbContextConfig dbContextConfig)
        {
            _dbContextConfig = dbContextConfig;
        }

        public async Task<Guid> CadastrarMovimento(Movimento movimento)
        {
            _dbContextConfig.Movimento.Add(movimento);
            await _dbContextConfig.SaveChangesAsync();
            return movimento.IdMovimento;
        }

        public async Task<double> ObterMovimentos(Guid idContaCorrente)
        {
            var movimentos = await _dbContextConfig.Movimento.Where(x => x.IdContaCorrente == idContaCorrente).ToListAsync();

            return !movimentos.Any() ? 0: movimentos.Where(x => x.TipoMovimento == 'C').Select(x => x.Valor).Sum() - 
                movimentos.Where(x => x.TipoMovimento == 'D').Select(x => x.Valor).Sum();
        }

       
    }
}
