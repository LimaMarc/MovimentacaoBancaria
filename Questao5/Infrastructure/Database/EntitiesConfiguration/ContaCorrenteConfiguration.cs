using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questao5.Domain.Entities.Business;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Questao5.Infrastructure.Database.EntitiesConfiguration
{
    public class ContaCorrenteConfiguration : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.HasKey(t => t.IdContaCorrente);
            builder.Property(n => n.Nome).HasMaxLength(100).IsRequired();
            builder.Property(n => n.Ativo).HasMaxLength(1).IsRequired();
            builder.Property(n => n.Numero).IsRequired();

           


            builder.HasData(
                new ContaCorrente(Guid.NewGuid(), 123, "Katherine Sanchez",1),
                new ContaCorrente(Guid.NewGuid(), 456, "Eva Woodward", 1),
                new ContaCorrente (Guid.NewGuid(), 789, "Tevin Mcconnell", 1),
                new ContaCorrente(Guid.NewGuid(), 741, "Ameena Lyn", 0),
                new ContaCorrente(Guid.NewGuid(), 852, "Jarrad Mcke", 0),
                new ContaCorrente(Guid.NewGuid(), 963, "Elisha Simons", 0)
            );

        }
    }
}
