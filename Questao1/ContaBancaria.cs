using System;
using System.Globalization;
using System.Security.Cryptography;

namespace Questao1
{
    class ContaBancaria {

        private const double taxaSaque = 3.50;

        public int numero { get;  set; }
        public string titular { get;  set; }
        public double depositoInicial { get; private set; }


        
        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
                this.numero = numero;
                this.titular = titular;
                ValidarDeposito(depositoInicial);
        }

        public ContaBancaria(int numero, string titular)
        {
            this.numero = numero;
            this.titular = titular;
        }

        private void ValidarDeposito(double valorDeposito)
        {
            //A intenção desses métodos internos a classe é justamente proporcionar uma validação ao objeto ContaBancaria
            //Aqui poderíamos ter Regras de negócio e/ou validações ligadas ao contexto desse objeto ContaBancaria. Assim
            //teríamos uma classe não anêmica.
            //Exemplo: Validar se uma conta já existe. 
            //Aqui vou colocar uma simples validação que verifica se o valor depositado é <=0
            if (valorDeposito <= 0)
                throw new System.Exception("Valor informado não pode ser Zero ou Negativo");

            depositoInicial += valorDeposito;

        }
        public void Deposito(double valorDeposito) => ValidarDeposito(valorDeposito);
        


        public void Saque(double valorSaque)
        {
            depositoInicial -= valorSaque;
            depositoInicial -= taxaSaque;

        }


        public override string ToString()
        {
            string dadosConta = String.Concat($"Conta: {numero} , ",
                                             $" Titular: {titular} ,",
                                             $"Saldo em R$: {depositoInicial}");

            return dadosConta;
        }

    }
}
