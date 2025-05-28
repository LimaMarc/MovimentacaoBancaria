using Moq;
using Questao5.Application.Arguments.Request;
using Questao5.Application.DomainServices.Services;
using Questao5.Domain.Entities.Business;
using Questao5.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Test.TestServices
{
    public class MovimentoServicesTest
    {
        private MovimentoService _movimentoService;

        public MovimentoServicesTest()
        {
            _movimentoService = new MovimentoService(new Mock<IMovimentoRepository>().Object,new Mock<IContaCorrenteRepository>().Object);
        }


        [Fact]
        public async void CadastrarMovimento_ComSucesso()
        {
            var movimento = new MovimentoCreate()
            {
                IdContaCorrente = new Guid("6EB8C77B-5FA1-4681-987B-077164A8C652"),
                TipoMovimento='C',
                Valor=1234.50
            };

            var movimentoCriado = await _movimentoService.CadastrarMovimento(movimento);

            Assert.True(movimento != null);
        }
    }

}
