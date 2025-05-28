using Questao5.Application.Arguments.Request;
using Questao5.Domain.Entities.Business;

namespace Questao5.Application.DomainServices.Interfaces
{
    public interface IMovimentoService
    {
        Task<Guid> CadastrarMovimento(MovimentoCreate movimentoCreateArgument);
    }
}
