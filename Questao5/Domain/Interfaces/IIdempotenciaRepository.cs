using Questao5.Domain.Entities.UserCase;

namespace Questao5.Domain.Interfaces
{
    public interface IIdempotenciaRepository
    {
        void CadastrarIdempotencia(Idempotencia idempotencia);
        Task<bool> ValidarIdempotenciaExistente(Guid idempotencia);
    }
}
