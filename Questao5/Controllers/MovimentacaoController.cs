using IdempotentAPI.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Questao5.Application.Arguments.Request;
using Questao5.Application.Arguments.Response;
using Questao5.Application.DomainServices.Interfaces;
using Questao5.Domain.Entities.Business;
using Questao5.Domain.Entities.UserCase;
using System.Net;

namespace Questao5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMovimentoService _movimentoService;
        private readonly IContaCorrenteService _correnteService;
        private readonly IIdempotenciaService _idempotenciaService;

        public MovimentacaoController(IMovimentoService movimentoService, IContaCorrenteService correnteService, IIdempotenciaService idempotenciaService)
        {
            _movimentoService = movimentoService;
            _correnteService = correnteService;
            _idempotenciaService = idempotenciaService;
        }

        /// <summary>
        /// Realiza a consulta de conta bancária retornado o saldo atual
        /// </summary>
        /// <param name="idContaCorrente"></param>
        /// <returns></returns>
        [HttpGet("{idContaCorrente:Guid}", Name = " Consultar Saldo Conta Corrente")]
        [ProducesResponseType(typeof(ContaCorrenteGetResponse), StatusCodes.Status200OK)]
       
        public  ActionResult<ContaCorrenteGetResponse> Get(Guid idContaCorrente)
        {

            try
            {
                var contaCorrente = _correnteService.ConsultarContaCorrente(idContaCorrente);
                              

                return Ok(contaCorrente);
            }
            catch (Exception ex)
            {

                return Problem(detail: ex.Message,
                    title: "Erro ao realizar operação de Consulta",
                    statusCode: (int)HttpStatusCode.BadRequest,
                    type: ex.InnerException?.Source);
            }




        }



        /// <summary>
        /// Realiza movimentação de crédito ou débito na conta bancária
        /// </summary>
        /// <param name="Movimento"></param>
        /// <returns></returns>
        [HttpPost("RealizarMovimentacao")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
       
        public async Task<ActionResult<Guid>> Post([FromBody] MovimentoCreate movimentoCreate)
        {
       
            HttpContext.Request.Headers.TryGetValue("IdempotencyKey", out var chaveIdempotencia);
            try
            {
                if (_idempotenciaService.ValidarIdempotenciaExistente(new Guid(chaveIdempotencia.First())).Result) return Ok();

                var movimentoId = await _movimentoService.CadastrarMovimento(movimentoCreate);
                _idempotenciaService.CadastrarIdempotencia(movimentoCreate, new Guid(chaveIdempotencia.First()));
                return Ok(movimentoId);
            }
            catch (Exception ex)
            {

                return Problem(detail:ex.Message, 
                    title:"Erro ao realizar operação de Movimentação", 
                    statusCode:(int)HttpStatusCode.BadRequest ,
                    type:ex.InnerException?.Source);
            }

  
        }
    }
}
