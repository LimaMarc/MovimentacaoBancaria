namespace Questao5.Domain.Entities.Business
{
    public class Movimento
    {

        public Guid IdMovimento { get; set; } = Guid.NewGuid();
        public string DataMovimento { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public char TipoMovimento { get; set; }
        public double Valor { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
        public Guid IdContaCorrente { get; set; }



        public Movimento(char tipoMovimento, double valor, Guid idContaCorrente)
        {

            ValidarTipoMovimento(tipoMovimento);
            ValidarValor(valor);
            IdContaCorrente = idContaCorrente;
        }


        #region  Validação de Domínio
   
        private void ValidarValor(double valor)
        {
            //Poderia criar uma classe de Domain Validation que lança exception
            //mas deixar de forma simples

            if (valor <= 0) throw new Exception("Valor de Movimento inválido", new Exception() { Source = "INVALID_VALUE" });

            Valor = valor;


        }

        private void ValidarTipoMovimento(char tipoMovimento)
        {
            //Poderia criar uma classe de Domain Validation 
            //e criar notification patterns para camadas de cima
            //mas preferi deixar simples

            if (tipoMovimento.ToString().ToUpper() == "C"
                || tipoMovimento.ToString().ToUpper() == "D")
                TipoMovimento = tipoMovimento;
            else
                throw new Exception("Tipo de Movimento Inválido", new Exception() { Source = "INVALID_TYPE"});


        }

        #endregion
    }
}
