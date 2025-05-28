using Questao5.Application.Arguments.Response;
using Questao5.Application.DomainServices.Interfaces;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Interfaces;

namespace Questao5.Application.DomainServices.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        public IMovimentoRepository _movimentoRepository;
        public IContaCorrenteRepository _contaCorrenteRepository;

        public ContaCorrenteService(IMovimentoRepository movimentoRepository, IContaCorrenteRepository contaCorrenteRepository)
        {
            _movimentoRepository = movimentoRepository;
            _contaCorrenteRepository = contaCorrenteRepository;
        }


        public ContaCorrenteGetResponse ConsultarContaCorrente(Guid idContaCorrente)
        {
            


            var contaCorrente = _contaCorrenteRepository.ConsultarContaCorrente(idContaCorrente).Result ?? throw new Exception("Conta Corrente Inválida", new Exception() { Source = "INVALID_ACCOUNT" });

            var contaExistente = contaCorrente.Ativo == (int)StatusConta.Ativa; 
            if (!contaExistente) throw new Exception("Conta Corrente Inativa", new Exception() { Source = "INACTIVE_ACCOUNT" });


            var saldoAtual = ConsultarMovimentosContaCorrente(idContaCorrente).Result;
            

            return new ContaCorrenteGetResponse()
            {
                Nome = contaCorrente.Nome,
                Numero = contaCorrente.Numero,
                Valor = saldoAtual
            };
        }

        public async Task<double> ConsultarMovimentosContaCorrente(Guid idContaCorrente)
        {
            return await _movimentoRepository.ObterMovimentos(idContaCorrente);
        }

    }
}
