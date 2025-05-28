using Questao5.Application.Arguments.Response;
using Questao5.Domain.Entities.Business;

namespace Questao5.Application.DomainServices.Interfaces
{
    public interface IContaCorrenteService
    {
        Task<double> ConsultarMovimentosContaCorrente(Guid idContaCorrente);
        ContaCorrenteGetResponse ConsultarContaCorrente(Guid idContaCorrente);
    }
}
