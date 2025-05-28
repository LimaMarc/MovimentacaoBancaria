using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questao5.Domain.Entities.Business;

namespace Questao5.Infrastructure.Database.EntitiesConfiguration
{
    public class MovimentoConfiguration : IEntityTypeConfiguration<Movimento>
    {
        public void Configure(EntityTypeBuilder<Movimento> builder)
        {
            builder.HasKey(t => t.IdMovimento);
            builder.Property(n => n.DataMovimento).HasMaxLength(25).IsRequired();
            builder.Property(n => n.TipoMovimento).HasMaxLength(1).IsRequired();
            builder.Property(n => n.Valor).HasPrecision(18, 2).IsRequired();
            builder.Property(n => n.TipoMovimento).HasMaxLength(1).IsRequired();

            builder.HasOne(e => e.ContaCorrente).WithMany(e => e.Movimento)
               .HasForeignKey(e => e.IdContaCorrente);


        }
    }
}
