using Newtonsoft.Json;
using Questao5.Application.Arguments.Request;
using Questao5.Application.Arguments.Response;
using Questao5.Application.DomainServices.Interfaces;
using Questao5.Domain.Entities.Business;
using Questao5.Domain.Entities.UserCase;
using Questao5.Domain.Interfaces;

namespace Questao5.Application.DomainServices.Services
{
    public class IdempotenciaService : IIdempotenciaService
    {
        public IIdempotenciaRepository _idempotenciaRepository;

        public IdempotenciaService(IIdempotenciaRepository idempotenciaRepository)
        {
            _idempotenciaRepository = idempotenciaRepository;
        }

        public void CadastrarIdempotencia(MovimentoCreate contaCorrente, Guid idempontencia)
        {
            string requisicaoSerializer = JsonConvert.SerializeObject(string.Concat("Consultando Saldo conta corrente : ", contaCorrente.IdContaCorrente), Formatting.Indented);
            string resultadoSerializer = JsonConvert.SerializeObject(contaCorrente, Formatting.Indented);
            var idempotencia = new Idempotencia(idempontencia,requisicaoSerializer, resultadoSerializer);
            _idempotenciaRepository.CadastrarIdempotencia(idempotencia);
        }

        public Task<bool> ValidarIdempotenciaExistente(Guid idempotencia)
        {
            return _idempotenciaRepository.ValidarIdempotenciaExistente(idempotencia);
        }
    }
}
