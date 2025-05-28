using Questao5.Application.Arguments.Request;


namespace Questao5.Application.DomainServices.Interfaces
{
    public interface IIdempotenciaService
    {
        void CadastrarIdempotencia(MovimentoCreate contaResponse, Guid idempontencia);
        Task<bool> ValidarIdempotenciaExistente(Guid idempotencia);
    }
}
