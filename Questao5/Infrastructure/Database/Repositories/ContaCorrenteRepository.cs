using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities.Business;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Database.Context;

namespace Questao5.Infrastructure.Database.Repositories
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private DbContextConfig _dbContextConfig;
        public ContaCorrenteRepository(DbContextConfig dbContextConfig)
        {
            _dbContextConfig = dbContextConfig;
        }
        public async Task<ContaCorrente> ConsultarContaCorrente(Guid numero)
        {
           
            return await _dbContextConfig.ContaCorrente.SingleAsync(x => x.IdContaCorrente == numero);
           
        }

        public async Task<bool> ConsultarContaCorrenteAtiva(Guid idContaCorrente)
        {
            var contaCorrenteAtiva = _dbContextConfig.ContaCorrente.Where(x => x.IdContaCorrente == idContaCorrente && x.Ativo == (int)StatusConta.Ativa).AsQueryable();

            return contaCorrenteAtiva.Any();
        }

        public async Task<bool> ConsultarContaCorrenteExistente(Guid idContaCorrente)
        {
            var contaCorrenteExistente =  _dbContextConfig.ContaCorrente.Where(x => x.IdContaCorrente == idContaCorrente).AsQueryable();

            return  contaCorrenteExistente.Any();
        }
    }
}
