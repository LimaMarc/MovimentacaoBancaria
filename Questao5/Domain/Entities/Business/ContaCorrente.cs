
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questao5.Domain.Entities.Business
{
    public class ContaCorrente
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid IdContaCorrente { get; set; }
        public int Numero { get; set; }
        public string Nome { get; set; }
        public byte Ativo { get; set; }
        public ICollection<Movimento> Movimento { get; set; }



        public ContaCorrente()
        {
            
        }
        public ContaCorrente(Guid IdContaCorrente, int numero, string nome, byte ativo)
        {
            this.IdContaCorrente = IdContaCorrente;
            Numero = numero;
            Nome = nome;
            Ativo = ativo;
        }
    }
}
