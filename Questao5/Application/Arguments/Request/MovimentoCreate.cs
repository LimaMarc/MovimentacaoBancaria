using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace Questao5.Application.Arguments.Request
{
 
    public class MovimentoCreate
    {


        /// <summary>
        /// Tipo Movimento 
        /// </summary>
        /// <example>(C=Crédito | D=Débito)</example>
        public char TipoMovimento { get; set; }



        /// <summary>
        /// Valor da movimentação
        /// </summary>
        /// <example>1500.48</example>
        [Precision(18,2)]
        public double Valor { get; set; }


        /// <summary>
        /// Identificador Conta Corrente
        /// </summary>
        /// <example>2ae83eb7-2391-4a83-8c15-a7076b08ea08</example>
        public Guid IdContaCorrente { get; set; }

    }
}
