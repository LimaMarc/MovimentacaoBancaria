using Questao5.Domain.Entities.Business;

namespace Questao5.Domain.Interfaces
{
    public interface IMovimentoRepository
    {
        Task<Guid> CadastrarMovimento(Movimento movimento);
        Task<double> ObterMovimentos(Guid idContaCorrente);
    }
}
