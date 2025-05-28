using Questao5.Application.Arguments.Request;
using Questao5.Application.DomainServices.Interfaces;
using Questao5.Domain.Entities.Business;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Database.Repositories;


namespace Questao5.Application.DomainServices.Services
{
    public class MovimentoService: IMovimentoService
    {
        public IMovimentoRepository _MovimentoRepository;
        public IContaCorrenteRepository _contaCorrenteRepository;

        public MovimentoService(IMovimentoRepository MovimentoRepository, IContaCorrenteRepository contaCorrenteRepository)
        {
            _MovimentoRepository = MovimentoRepository;
            _contaCorrenteRepository = contaCorrenteRepository;

        }

        public async Task<Guid> CadastrarMovimento(MovimentoCreate movimentoCreateArgument)
        {
            var contaExistente = await _contaCorrenteRepository.ConsultarContaCorrenteExistente(movimentoCreateArgument.IdContaCorrente);
            if (!contaExistente) throw new Exception("Conta Corrente inválida", new Exception() { Source= "INVALID_ACCOUNT" });



            var contaAtiva = await _contaCorrenteRepository.ConsultarContaCorrenteAtiva(movimentoCreateArgument.IdContaCorrente);
            if (!contaAtiva) throw new Exception("Conta Corrente Inativa", new Exception() { Source = "INACTIVE_ACCOUNT" });

         
            var movimentoDomninio = new Movimento(movimentoCreateArgument.TipoMovimento, movimentoCreateArgument.Valor, movimentoCreateArgument.IdContaCorrente);
            return await _MovimentoRepository.CadastrarMovimento(movimentoDomninio);
        }
    }
}
