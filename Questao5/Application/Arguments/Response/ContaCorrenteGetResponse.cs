namespace Questao5.Application.Arguments.Response
{
    public class ContaCorrenteGetResponse
    {
        /// <summary>
        /// Numero Conta
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Dados do correntista
        /// </summary>
        public string Nome { get; set; }


        /// <summary>
        /// Saldo atual Créditos - Débitos
        /// </summary>
        public double Valor { get; set; }


        /// <summary>
        /// Data consulta
        /// </summary>
        public string Data { get; set; } = DateTime.Now.ToString();


        
    }
}
