namespace Questao5.Domain.Entities.UserCase
{
    public class Idempotencia
    {
        public Guid ChaveIdempotencia { get; set; }

        public string Requisicao { get; set; }

        public string Resultado  { get; set; }

        public Idempotencia()
        {
            
        }
        public Idempotencia(Guid ChaveIdempotencia, string Requisicao, string Resultado)
        {
            this.ChaveIdempotencia = ChaveIdempotencia;
            this.Requisicao = Requisicao;
            this.Resultado = Resultado;
        }


    }
}
