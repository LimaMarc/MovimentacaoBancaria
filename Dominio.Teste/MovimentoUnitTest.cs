using Questao5.Domain.Entities.Business;

namespace Dominio.Teste
{
    public class MovimentoUnitTest
    {
        [Fact(DisplayName = "Criar Movimento Bancário válido")]
        public void CriarMovimentoCredito_ComArgumentosValido_ResultadoObjetoValido()
        {
            Action action = () => new Movimento('C', 24605, Guid.NewGuid());
            action.Should()
                .NotThrow<Exception>();
        }

        [Fact(DisplayName = "Criar Movimento Bancário válido")]
        public void CriarMovimentoDebito_ComArgumentosValido_ResultadoObjetoValido()
        {
            Action action = () => new Movimento('D', 1000, Guid.NewGuid());
            action.Should()
                .NotThrow<Exception>();
        }


        [Fact(DisplayName = "Criar Movimento Bancário inválido")]
        public void CriarMovimento_ComTipoArgumentoInvalido_Exception()
        {
            Action action = () => new Movimento('A', 24605, Guid.NewGuid());
            action.Should()
                .Throw<Exception>()
                .WithMessage("Tipo de movimento inválido");
        }

        
        [Fact(DisplayName = "Criar Movimento Bancário inválido")]
        public void CriarMovimento_ComValorInvalido_Exception()
        {
            Action action = () => new Movimento('C', -290, Guid.NewGuid());
            action.Should()
                .Throw<Exception>()
                .WithMessage("Valor de movimento inválido");
        }

        
    }
}
