using Questao5.Domain.Entities.Business;

namespace Questao5.Domain.Interfaces
{
    public interface IContaCorrenteRepository
    {
        Task<ContaCorrente> ConsultarContaCorrente(Guid idContaCorrente);
        Task<bool> ConsultarContaCorrenteExistente(Guid idContaCorrente);

        Task<bool> ConsultarContaCorrenteAtiva(Guid idContaCorrente);
    }
}
